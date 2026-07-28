using com.clusterrr.hakchi_gui.Properties;
using com.clusterrr.hakchi_gui.Tasks;
using com.clusterrr.util;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static com.clusterrr.hakchi_gui.Tasks.Tasker;

namespace com.clusterrr.hakchi_gui.ModHub.Repository
{
    public delegate void RepositoryProgressHandler(long current, long max);
    public delegate void RepositoryLoadedHandler(Repository.Item[] items);

    public static class ItemKindMethods
    {
        public static string GetFileExtension(this Repository.ItemKind kind)
        {
            return Repository.ItemKindFileExtensions[(int)kind];
        }
    }

    public class Repository
    {
        public event RepositoryProgressHandler RepositoryProgress;
        public event RepositoryLoadedHandler RepositoryLoaded;

        public string RepositoryURL { get; private set; }
        public string FallbackPackURL { get; private set; }

        public string RepositoryPackURL
        {
            get
            {
                return RepositoryURL + "pack.tgz";
            }
        }

        public string RepositoryListURL
        {
            get
            {
                return RepositoryURL + "list";
            }
        }

        public List<Item> Items = new List<Item>();
        public string Readme { get; private set; } = null;

        // Fallback: raw GitHub URL for pack.tgz mirror
        // Place your pack.tgz at: https://raw.githubusercontent.com/Exeqtr-RED/Hakchi3/master/hmods/pack.tgz
        private const string FALLBACK_GITHUB_PACK_URL = "https://raw.githubusercontent.com/Exeqtr-RED/Hakchi3/master/hmods/pack.tgz";
        private const int REQUEST_TIMEOUT_MS = 15000;

        public static string[] ItemKindFileExtensions = new string[] { null, ".hmod", ".clvg" };
        public enum ItemKind
        {
            Unknown,
            Hmod,
            Game
        }

        public static ItemKind ItemKindFromFilename(string filename)
        {
            string lowerFilename = filename.ToLower();

            foreach (ItemKind kind in Enum.GetValues(typeof(ItemKind)))
            {
                if (kind == ItemKind.Unknown)
                    continue;
                if (lowerFilename.EndsWith(kind.GetFileExtension()))
                    return kind;
            }

            return ItemKind.Unknown;
        }

        public class Item
        {
            public string FileName { get; private set; }
            public string RawName
            {
                get
                {
                    if (FileName.EndsWith(".hmod") || FileName.EndsWith(".clvg"))
                        return FileName.Substring(0, FileName.Length - 5);

                    return FileName;
                }
            }
            public string CleanName
            {
                get
                {
                    if (Kind == ItemKind.Hmod)
                        return Hmod.Hmod.GetCleanName(RawName, true);

                    return RawName;
                }
            }
            public string Name { get; private set; }
            public string Category { get; private set; }
            public string Creator { get; private set; }
            public string Version { get; private set; }
            public string EmulatedSystem { get; private set; }
            public string URL { get; private set; }
            public string MD5 { get; private set; }
            public string SHA1 { get; private set; }
            public bool Extract { get; private set; }

            public ItemKind Kind { get; private set; }
            public HmodReadme Readme { get; private set; }

            public Item(string filename, string readme = null, bool markdownReadme = false)
            {
                FileName = filename;
                Kind = ItemKindFromFilename(FileName);
                Name = RawName;
                Category = null;
                Creator = null;
                Version = null;
                EmulatedSystem = null;
                URL = null;
                MD5 = null;
                SHA1 = null;
                Extract = false;
                Readme = new HmodReadme(readme ?? "", markdownReadme);
                setValues();
            }
            public void setURL(string url)
            {
                URL = url;
            }
            public void setMD5(string md5)
            {
                MD5 = md5;
            }
            public void setSHA1(string sha1)
            {
                SHA1 = sha1;
            }
            public void setExtract(bool extract)
            {
                Extract = extract;
            }
            public void setReadme(string readme, bool markdown = false)
            {
                Readme = new HmodReadme(readme, markdown);
                setValues();
            }
            private void setValues()
            {
                Name = Readme.frontMatter.ContainsKey("Name") ? Readme.frontMatter["Name"] : CleanName;
                Category = Readme.frontMatter.ContainsKey("Category") ? Readme.frontMatter["Category"] : null;
                Creator = Readme.frontMatter.ContainsKey("Creator") ? Readme.frontMatter["Creator"] : null;
                Version = Readme.frontMatter.ContainsKey("Version") ? Readme.frontMatter["Version"] : null;
                EmulatedSystem = Readme.frontMatter.ContainsKey("Emulated System") ? Readme.frontMatter["Emulated System"] : null;
            }
        }

        public Repository(string repositoryURL)
        {
            this.RepositoryURL = repositoryURL + (repositoryURL.EndsWith("/") ? "" : "/");
            this.RepositoryURL = RepositoryURL + (RepositoryURL.EndsWith("/.repo/") ? "" : ".repo/");
            this.FallbackPackURL = FALLBACK_GITHUB_PACK_URL;
        }

        // Constructor with explicit fallback URL
        public Repository(string repositoryURL, string fallbackPackURL)
        {
            this.RepositoryURL = repositoryURL + (repositoryURL.EndsWith("/") ? "" : "/");
            this.RepositoryURL = RepositoryURL + (RepositoryURL.EndsWith("/.repo/") ? "" : ".repo/");
            this.FallbackPackURL = fallbackPackURL;
        }

        private string StreamToString(Stream stream)
        {
            if (stream.CanSeek)
                stream.Position = 0;

            using (var sr = new StreamReader(stream, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Downloads pack.tgz with proper timeout, TLS 1.2, and User-Agent.
        /// Returns the response stream on success, null on failure.
        /// </summary>
        private HTTPHelpers.StatusStream? DownloadPackTgz(string url, string label)
        {
            Trace.WriteLine($"[ModHub] Trying {label}: {url}");

            try
            {
                // Ensure TLS 1.2 is available (required by many modern servers)
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = REQUEST_TIMEOUT_MS;
                request.ReadWriteTimeout = REQUEST_TIMEOUT_MS;
                request.UserAgent = "hakchi/3.0";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(
                    System.Net.Cache.RequestCacheLevel.BypassCache);
                request.AllowAutoRedirect = true;

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Trace.WriteLine($"[ModHub] Success from {label}, ContentLength={response.ContentLength}");
                    return new HTTPHelpers.StatusStream(response.StatusCode, response.GetResponseStream(), response.ContentLength);
                }
                else
                {
                    Trace.WriteLine($"[ModHub] {label} returned status {response.StatusCode}");
                    response.Dispose();
                    return new HTTPHelpers.StatusStream(response.StatusCode);
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine($"[ModHub] {label} failed: {ex.Status} - {ex.Message}");
                if (ex.Response != null)
                {
                    try { ex.Response.Close(); } catch { }
                }
                return null;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[ModHub] {label} error: {ex.Message}");
                return null;
            }
        }

        public void Load()
        {
            string[] list = new string[] { };
            HTTPHelpers.StatusStream? repoResponse = null;

            // === Try primary URL first ===
            repoResponse = DownloadPackTgz(RepositoryPackURL, "Primary");

            // === If primary failed, try fallback ===
            if (repoResponse == null || repoResponse.Value.Status != HttpStatusCode.OK)
            {
                Trace.WriteLine("[ModHub] Primary failed, trying fallback...");
                repoResponse = DownloadPackTgz(FallbackPackURL, "Fallback");
            }

            // === Both failed ===
            if (repoResponse == null || repoResponse.Value.Status != HttpStatusCode.OK)
            {
                throw new Exception("KMFDs Mod Hub is unavailable. Both primary and fallback servers failed.");
            }

            // === Process pack.tgz ===
            try
            {
                var response = repoResponse.Value;
                var tempDict = new Dictionary<string, Item>();
                var trackableStream = new TrackableStream(response.Stream);
                trackableStream.OnProgress += (long current, long total) =>
                {
                    RepositoryProgress?.Invoke(current, response.Length);
                };

                using (var decompressedStream = new System.IO.Compression.GZipStream(trackableStream, System.IO.Compression.CompressionMode.Decompress))
                using (var reader = ReaderFactory.OpenReader(decompressedStream))
                {
                    while (reader.MoveToNextEntry())
                    {
                        if (Regex.Match(reader.Entry.Key, @"^(?:\./)?list$", RegexOptions.IgnoreCase).Success)
                        {
                            list = Regex.Replace(StreamToString(reader.OpenEntryStream()), @"[\r\n]+", "\n").Split("\n"[0]);
                        }

                        if (Regex.Match(reader.Entry.Key, @"^(?:\./)?readme\.md$", RegexOptions.IgnoreCase).Success)
                        {
                            Readme = StreamToString(reader.OpenEntryStream());
                        }

                        var match = Regex.Match(reader.Entry.Key, @"^(?:\./)?([^/]+)/(extract|link|md5|sha1|readme(?:\.(?:md|txt)?)?)$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            var mod = match.Groups[1].ToString();
                            var fileName = match.Groups[2].ToString();

                            Item item;

                            if (!tempDict.TryGetValue(mod, out item))
                            {
                                item = new Item(mod);
                                tempDict.Add(mod, item);
                            }

                            switch (fileName.ToLower())
                            {
                                case "extract":
                                    item.setExtract(true);
                                    break;

                                case "link":
                                    item.setURL(StreamToString(reader.OpenEntryStream()).Trim());
                                    break;

                                case "md5":
                                    item.setMD5(StreamToString(reader.OpenEntryStream()).Trim());
                                    break;

                                case "sha1":
                                    item.setSHA1(StreamToString(reader.OpenEntryStream()).Trim());
                                    break;

                                case "readme":
                                case "readme.txt":
                                case "readme.md":
                                    item.setReadme(StreamToString(reader.OpenEntryStream()).Trim(), fileName.EndsWith(".md"));
                                    break;
                            }
                        }
                    }
                }

                if (list.Length == 0)
                    list = tempDict.Keys.ToArray();

                foreach (var key in tempDict.Keys.ToArray())
                {
                    var item = tempDict[key];
                    if (list.Contains(key))
                    {
                        Items.Add(item);
                    }
                    tempDict.Remove(key);
                }
                tempDict.Clear();
                tempDict = null;
                Items.Sort((x, y) => x.Name.CompareTo(y.Name));
                RepositoryLoaded?.Invoke(Items.ToArray());
            }
            finally
            {
                // Make sure the HTTP response stream is disposed
                try { repoResponse.Value.Stream?.Dispose(); } catch { }
            }
        }

        public Item[] LoadTasker(Form hostForm)
        {
            using (var tasker = new Tasks.Tasker(hostForm))
            {
                tasker.AttachViews(new TaskerTaskbar(), new TaskerForm());
                tasker.SetStatusImage(Resources.sign_cogs);
                tasker.SetTitle("Loading Repository");
                tasker.AddTask(LoadTask);
                if (tasker.Start() == Tasker.Conclusion.Success)
                {
                    return Items.ToArray();
                }
                return null;
            }
        }

        private Conclusion LoadTask(Tasker tasker, Object syncObject)
        {
            tasker.SetStatus("Loading...");
            RepositoryProgress += (long current, long max) =>
            {
                tasker.SetProgress(current, max);
            };
            Load();
            return Conclusion.Success;
        }
    }
}
