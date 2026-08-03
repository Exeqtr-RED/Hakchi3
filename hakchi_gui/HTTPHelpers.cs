using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace com.clusterrr.hakchi_gui
{
    class HTTPHelpers
    {
        public struct StatusStream
        {
            public HttpStatusCode Status { get; private set; }
            public Stream Stream { get; private set; }
            public long Length { get; private set; }
            public StatusStream(HttpStatusCode status, Stream stream = null, long length = 0)
            {
                this.Status = status;
                this.Stream = stream;
                this.Length = length;
            }
        }

        private static readonly HttpClient httpClient = new HttpClient();

        static HTTPHelpers()
        {
            httpClient.DefaultRequestHeaders.CacheControl =
                new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public static async Task<HttpStatusCode> GetHTTPStatusCodeAsync(string url)
        {
            try
            {
                using var response = await httpClient.GetAsync(url,
                    HttpCompletionOption.ResponseHeadersRead);

                    return response.StatusCode;

                
            }
            catch (Exception)
            {
                return HttpStatusCode.ServiceUnavailable;
            }
        }

        public static async Task<StatusStream> GetHTTPResponseStreamAsync(string url)
        {
            try
            {
                var response = await httpClient.GetAsync(url,
                    HttpCompletionOption.ResponseHeadersRead);

                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    long length = response.Content.Headers.ContentLength ?? -1;
                    // response не диспоузим — Stream привязан к нему,
                    // диспоуз Stream вернёт соединение в пул
                    return new StatusStream(response.StatusCode, stream, length);
                }

                response.Dispose();
                return new StatusStream(response.StatusCode);
            }
            catch (Exception)
            {
                return new StatusStream(HttpStatusCode.ServiceUnavailable);
            }
        }

        public static async Task<string> GetHTTPResponseStringAsync(string url, Encoding encoding = null)
        {
            try
            {
                using var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                    var bytes = await response.Content.ReadAsByteArrayAsync();
                    return (encoding ?? Encoding.UTF8).GetString(bytes);
                    }
                    return null;

                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
