using Newtonsoft.Json;

namespace Doppler.UpcStore.Proxy
{
    public class Error : IUpcHeader
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}