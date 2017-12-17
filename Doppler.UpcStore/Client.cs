using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Doppler.Core.Extension;
using Doppler.UpcStore.Proxy;

namespace Doppler.UpcStore
{
    public class Client
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public Client(string baseUri, string apiKey = null)
        {
            _apiKey = apiKey;
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromSeconds(20);
        }

        public async Task<UpcResponse> GetAsync(string id)
        {
            var response = await _client.GetAsync(BuildRequest(id));
            var stream = await response.Content.ReadAsStreamAsync();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return stream.Deserialize<UpcResponse>();

            var error = stream.Deserialize<Error>();
            throw new HttpRequestException($"Error code {error.Code}. Message {error.Message}");
        }

        private static string BuildRequest(string id)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                $"/prod/trial/lookup?upc={id}");
        }
    }
}