using com.clusterrr.util;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using static com.clusterrr.hakchi_gui.Tasks.Tasker;

namespace com.clusterrr.hakchi_gui.Tasks
{
    class WebClientTasks
    {
        private const int CONNECTION_TIMEOUT_MS = 15000;
        private const int DOWNLOAD_TIMEOUT_MS = 120000;

        // HttpClient is thread-safe and intended to be reused across the application lifetime.
        // Configured for streamed downloads with no built-in buffer so progress can be tracked accurately.
        private static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.None
        })
        {
            Timeout = TimeSpan.FromMilliseconds(DOWNLOAD_TIMEOUT_MS)
        };

        public static TaskFunc DownloadFile(string url, string fileName, bool successOnError = false, bool onlyLatest = false, DateTime? comparisonDate = null, bool gunzip = false)
        {
            return (Tasker tasker, Object sync) =>
            {
                Conclusion result = Conclusion.Success;

                Debug.WriteLine($"Downloading: {url} to {fileName}");

                if (comparisonDate == null && File.Exists(fileName))
                {
                    comparisonDate = File.GetLastWriteTime(fileName);
                }

                // Ensure TLS 1.2 is available
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    request.Headers.UserAgent.ParseAdd(HakchiWebClient.UserAgent);

                    try
                    {
                        using (var response = HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result)
                        {
                            response.EnsureSuccessStatusCode();

                            var headers = response.Headers;
                            var contentLength = response.Content.Headers.ContentLength ?? 0;

                            var date = DateTime.Now;

                            if (headers.TryGetValues("Last-Modified", out var lastModifiedValues))
                            {
                                var lastModified = lastModifiedValues.FirstOrDefault();
                                if (!string.IsNullOrEmpty(lastModified))
                                {
                                    date = DateTime.ParseExact(lastModified,
                                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                        CultureInfo.InvariantCulture.DateTimeFormat,
                                        DateTimeStyles.AssumeUniversal);

                                    if (onlyLatest && comparisonDate != null && comparisonDate >= date)
                                    {
                                        return Conclusion.Success;
                                    }
                                }
                            }

                            using (var webStream = response.Content.ReadAsStreamAsync().Result)
                            using (var trackableStream = new TrackableStream(webStream))
                            {
                                trackableStream.OnProgress += (progress, max) =>
                                {
                                    tasker.SetStatus($"{Shared.SizeSuffix(progress)}{(contentLength > 0 ? $" / {Shared.SizeSuffix(contentLength)}" : "")}");
                                    tasker.SetProgress(progress, contentLength);
                                };

                                using (var outputFile = File.Create(fileName))
                                {

                                    if (gunzip)
                                    {
                                        using (var gzipStream = new GZipStream(trackableStream, CompressionMode.Decompress))
                                        {
                                            gzipStream.CopyTo(outputFile);
                                        }
                                    }
                                    else
                                    {
                                        trackableStream.CopyTo(outputFile);
                                    }
                                }
                                File.SetLastWriteTime(fileName, date);
                            }
                        }
                    }
                    catch (OperationCanceledException) { }
                    catch (Exception)
                    {
                        if (!successOnError)
                            throw;
                    }

                    return result;
                }
            };
        }
    }
}
