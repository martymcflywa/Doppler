using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Doppler.Core.Exception;
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

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: // we got stuff!
                    var content = await response.Content.ReadAsStringAsync();
                    return content.Deserialize<UpcResponse>();
                case HttpStatusCode.NotFound:
                case HttpStatusCode.BadRequest: // invalid query, missing parameters
                    throw new UpcNotFoundException(id);
                case (HttpStatusCode) 429: // exceed request limit
                    throw new UpcStoreRequestLimitExceededException();
                case HttpStatusCode.InternalServerError:
                    throw new InternalUpcStoreErrorException();
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                default:
                    throw new Exception("Unknown fatal error attempting to access upc store.");
            }
        }

        private static string BuildRequest(string id)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                $"/prod/trial/lookup?upc={id}");
        }
    }
}