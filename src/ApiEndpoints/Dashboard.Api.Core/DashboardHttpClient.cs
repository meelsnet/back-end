using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dashboard.Settings.Settings;
using Dashboard.Helpers;
using Dashboard.Settings.Settings.Models;

namespace Dashboard.Api.Core
{
    public class DashboardHttpClient : IDashboardHttpClient
    {
        public DashboardHttpClient(ICacheService cache, ISettingsService<DashboardSettings> s)
        {
            _cache = cache;
            _settings = s;
            _runtimeVersion = AssemblyHelper.GetRuntimeVersion();
        }

        private static HttpClient _client;
        private static HttpMessageHandler _handler;

        private readonly ICacheService _cache;
        private readonly ISettingsService<DashboardSettings> _settings;
        private readonly string _runtimeVersion;


        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            await Setup();
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Setup();
            return await _client.SendAsync(request, cancellationToken);
        }

        public async Task<string> GetStringAsync(Uri requestUri)
        {
            await Setup();
            return await _client.GetStringAsync(requestUri);
        }

        private async Task Setup()
        {
            if (_client == null)
            {
                if (_handler == null)
                {
                    // Get the handler
                    _handler = await GetHandler();
                }
                _client = new HttpClient(_handler);
                _client.DefaultRequestHeaders.Add("User-Agent", $"Dashboard/{_runtimeVersion} (https://meelsnet.nl/)");
            }
        }

        private async Task<HttpMessageHandler> GetHandler()
        {
            var settings = await _cache.GetOrAdd(CacheKeys.DashboardSettings, async () => await _settings.GetSettingsAsync(), DateTime.Now.AddHours(1));
            if (settings.IgnoreCertificateErrors)
            {
                return new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true,
                };
            }
            return new HttpClientHandler();
        }
    }
}