using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable SYSLIB0014

namespace com.clusterrr.hakchi_gui.Controls
{
    public partial class ImageGoogler : UserControl
    {
        private const string SearchUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/126.0.0.0 Safari/537.36";

        public struct SearchQuery
        {
            public string Query;
            public string AdditionalVariables;
        }

        public delegate void ImageReceived(Image image);
        public delegate void ImageDeselected();
        public event ImageReceived OnImageSelected;
        public event ImageReceived OnImageDoubleClicked;
        public event ImageDeselected OnImageDeselected;

        public List<SearchQuery> Queries { get; } = new List<SearchQuery>();
        private CancellationTokenSource searchCts;
        private readonly List<string> downloadedUrls = new List<string>();

        public ImageGoogler()
        {
            InitializeComponent();
        }

        public void Deselect()
        {
            foreach (var item in listView.Items.Cast<ListViewItem>())
            {
                if (item.Selected)
                    item.Selected = false;
            }
        }

        public void RunQuery(params Bitmap[] customResults)
        {
            imageList.Images.Clear();
            listView.Items.Clear();
            downloadedUrls.Clear();

            searchCts?.Cancel();
            searchCts?.Dispose();
            searchCts = new CancellationTokenSource();
            var token = searchCts.Token;

            Task.Run(() =>
            {
                foreach (var image in customResults)
                {
                    if (token.IsCancellationRequested) return;
                    ShowImage(image);
                }

                foreach (var query in Queries)
                {
                    if (token.IsCancellationRequested) return;
                    SearchThread(query.Query, query.AdditionalVariables, token);
                }
            }, token);
        }

        public static string[] GetImageUrls(string query, string additionalVariables = "", int tryCount = 0)
        {
            if (tryCount > 0)
                Trace.WriteLine(string.Format("Retry #" + tryCount));

            var urls = new List<string>();

            try
            {
                urls.AddRange(GetDuckDuckGoImageUrls(query));
                Trace.WriteLine(string.Format("DuckDuckGo image results: " + urls.Count));
            }
            catch (Exception ex)
            {
                Trace.WriteLine("DuckDuckGo image search failed: " + ex.Message);
                if (ex.InnerException != null)
                    Trace.WriteLine(ex.InnerException.Message);
            }

            if (urls.Count == 0)
            {
                try
                {
                    urls.AddRange(GetBingImageUrls(query, additionalVariables));
                    Trace.WriteLine(string.Format("Bing image results: " + urls.Count));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Bing image search failed: " + ex.Message);
                    if (ex.InnerException != null)
                        Trace.WriteLine(ex.InnerException.Message);
                }
            }

            if (urls.Count == 0 && tryCount < 2)
                return GetImageUrls(query, additionalVariables, tryCount + 1);

            if (urls.Count == 0)
                Trace.WriteLine("No image results found");

            return urls.ToArray();
        }

        private static string[] GetDuckDuckGoImageUrls(string query)
        {
            var cookies = new CookieContainer();
            string encodedQuery = WebUtility.UrlEncode(query);
            string searchPageUrl = "https://duckduckgo.com/?q=" + encodedQuery;
            Trace.WriteLine("Web request: " + searchPageUrl);

            string searchPage = DownloadText(searchPageUrl, cookies);
            Match vqdMatch = Regex.Match(searchPage, @"vqd=[""'](?<vqd>[^""']+)", RegexOptions.IgnoreCase);
            if (!vqdMatch.Success)
                vqdMatch = Regex.Match(searchPage, @"vqd=(?<vqd>[0-9-]+)", RegexOptions.IgnoreCase);

            if (!vqdMatch.Success)
                throw new InvalidDataException("DuckDuckGo did not return an image-search token.");

            string vqd = vqdMatch.Groups["vqd"].Value;
            string imageSearchUrl = "https://duckduckgo.com/i.js?l=us-en&o=json&q=" + encodedQuery + "&vqd=" + WebUtility.UrlEncode(vqd) + "&f=,,,&p=1";
            Trace.WriteLine("Web request: " + imageSearchUrl);

            string json = DownloadText(imageSearchUrl, cookies, searchPageUrl, true);
            var urls = new List<string>();

            using (JsonDocument document = JsonDocument.Parse(json))
            {
                JsonElement results;
                if (!document.RootElement.TryGetProperty("results", out results) || results.ValueKind != JsonValueKind.Array)
                    return urls.ToArray();

                foreach (JsonElement result in results.EnumerateArray())
                {
                    JsonElement imageUrl;
                    if (result.TryGetProperty("image", out imageUrl))
                        AddImageUrl(urls, imageUrl.GetString());

                    if (urls.Count >= 60)
                        break;
                }
            }

            return urls.ToArray();
        }

        private static string[] GetBingImageUrls(string query, string additionalVariables)
        {
            var cookies = new CookieContainer();
            DownloadText("https://www.bing.com/", cookies);

            string encodedQuery = WebUtility.UrlEncode(query);
            string filter = "";
            if (!string.IsNullOrEmpty(additionalVariables) && additionalVariables.IndexOf("ic:trans", StringComparison.OrdinalIgnoreCase) >= 0)
                filter = "&qft=+filterui:photo-transparent";

            string url = "https://www.bing.com/images/async" +
                "?q=" + encodedQuery + "&first=1&count=35&cw=1177&ch=758&relp=35" +
                "&tsc=ImageBasicHover&datsrc=I&layout=RowBased_Landscape&mmasync=1&SFX=1" +
                "&cc=US&setlang=en-US&adlt=off" + filter;
            Trace.WriteLine("Web request: " + url);

            string html = DownloadText(url, cookies, "https://www.bing.com/", true);
            var urls = new List<string>();
            MatchCollection matches = Regex.Matches(
                html,
                @"\sm=""(?<metadata>\{&quot;.*?\})""",
                RegexOptions.IgnoreCase | RegexOptions.Singleline
            );

            foreach (Match match in matches)
            {
                try
                {
                    string metadata = WebUtility.HtmlDecode(match.Groups["metadata"].Value);
                    using (JsonDocument document = JsonDocument.Parse(metadata))
                    {
                        JsonElement imageUrl;
                        if (document.RootElement.TryGetProperty("murl", out imageUrl))
                            AddImageUrl(urls, imageUrl.GetString());
                    }
                }
                catch (JsonException)
                {
                }
            }

            return urls.ToArray();
        }

        private static string DownloadText(string url, CookieContainer cookies, string referer = null, bool ajaxRequest = false)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.CookieContainer = cookies;
            request.UserAgent = SearchUserAgent;
            request.Accept = "text/html,application/xhtml+xml,application/json;q=0.9,*/*;q=0.8";
            request.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.9";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Timeout = 15000;
            request.ReadWriteTimeout = 15000;
            request.KeepAlive = false;

            if (!string.IsNullOrEmpty(referer))
                request.Referer = referer;
            if (ajaxRequest)
                request.Headers["X-Requested-With"] = "XMLHttpRequest";

            using (var response = (HttpWebResponse)request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            using (var reader = new StreamReader(dataStream))
                return reader.ReadToEnd();
        }

        private static void AddImageUrl(List<string> urls, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            url = WebUtility.HtmlDecode(url.Trim());
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                return;
            if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
                return;
            if (!urls.Any(existing => string.Equals(existing, url, StringComparison.OrdinalIgnoreCase)))
                urls.Add(url);
        }

        private void SearchThread(string query, string additionalVariables, CancellationToken token)
        {
            try
            {
                var urls = GetImageUrls(query, additionalVariables);
                foreach (var url in urls)
                {
                    if (token.IsCancellationRequested) return;

                    try
                    {
                        if (!downloadedUrls.Contains(url))
                        {
                            downloadedUrls.Add(url);
                            Trace.WriteLine("Downloading image: " + url);
                            var image = DownloadImage(url);
                            ShowImage(image);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Unable to download image: " + ex.Message);
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        protected void ShowImage(Image image)
        {
            try
            {
                if (this.Disposing || this.IsDisposed)
                    return;
                if (InvokeRequired)
                {
                    Invoke(new Action<Image>(ShowImage), new object[] { image });
                    return;
                }

                int i = imageList.Images.Count;
                const int side = 256;
                var imageRect = new Bitmap(side, side, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (var gr = Graphics.FromImage(imageRect))
                {
                    gr.Clear(Color.White);
                    if (image.Height > image.Width)
                        gr.DrawImage(image, new Rectangle((side - side * image.Width / image.Height) / 2, 0, side * image.Width / image.Height, side),
                            new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                    else
                        gr.DrawImage(image, new Rectangle(0, (side - side * image.Height / image.Width) / 2, side, side * image.Height / image.Width),
                            new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                    gr.Flush();
                }

                listView.BeginUpdate();
                imageList.Images.Add(imageRect);
                var item = new ListViewItem(image.Width + "x" + image.Height)
                {
                    ImageIndex = i,
                    Tag = image
                };
                listView.Items.Add(item);
                listView.EndUpdate();
                listView.Update();
            }
            catch { }
        }

        public static Image DownloadImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
            request.ReadWriteTimeout = 10000;
            request.UserAgent = SearchUserAgent;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.KeepAlive = false;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            using (var downloadedImage = Image.FromStream(dataStream))
                return new Bitmap(downloadedImage);
        }

        private Image GetSelectedImage()
        {
            if (listView.SelectedItems.Count == 0)
                return null;
            return listView.SelectedItems[0].Tag as Image;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            Image selected;
            if ((selected = GetSelectedImage()) != null)
                this.OnImageDoubleClicked?.Invoke(selected);
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Image selected;
            if ((selected = GetSelectedImage()) != null)
                this.OnImageSelected?.Invoke(selected);
            else
                this.OnImageDeselected?.Invoke();
        }
    }
}
