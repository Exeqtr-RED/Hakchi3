using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace com.clusterrr.hakchi_gui
{
    /// <summary>
    /// Provides a shared <see cref="HttpClient"/> pre-configured with the
    /// hakchi User-Agent. Replaces the legacy <c>HakchiWebClient : WebClient</c>
    /// subclass which was deprecated in .NET 6+.
    /// </summary>
    internal static class HakchiWebClient
    {
        public static readonly string UserAgent = $"Hakchi3/{Shared.AppVersion.ToString()} (https://github.com/Exeqtr-RED/Hakchi3)";

        /// <summary>
        /// Shared HttpClient instance. Reuse across the app — do not wrap in 'using'.
        /// </summary>
        public static readonly HttpClient HttpClient = new HttpClient();

        static HakchiWebClient()
        {
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            HttpClient.Timeout = TimeSpan.FromSeconds(30);
        }
    }
}
