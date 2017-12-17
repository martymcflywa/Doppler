using Newtonsoft.Json;

namespace Doppler.UpcStore.Proxy
{
    public interface IUpcHeader
    {
        [JsonProperty("code")]
        string Code { get; set; }
    }
}