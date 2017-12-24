using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Doppler.Core;

namespace Doppler.Frontend.Web.Controllers
{
    public class DopplerStore : IApiConsumer
    {
        private readonly HttpClient _client;

        public DopplerStore(string baseUrl = "http://localhost:5000")
        {
            // TODO: add baseUrl as property in appsettings.json
            _client = BuildHttpClient(baseUrl);
        }

        private static HttpClient BuildHttpClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(20);
            return client;
        }

        private static string BuildUpcRequest(string upcId)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                $"/api/upc/{upcId}");
        }

        public async Task<string> GetMovieByUpcAsync(string upcId)
        {
            try
            {

            }
            catch (HttpRequestException ex)
            {
                // Todo: handle case where api server is down
            }
            var response = await _client.GetAsync(BuildUpcRequest(upcId));
            // TODO: handle non OK responses
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public Task<string> GetMovieByTitleYearAsync(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetMovieByExternalId(string source, string id)
        {
            throw new System.NotImplementedException();
        }
    }
}