using System.Collections.Generic;
using Newtonsoft.Json;

namespace Doppler.UpcStore.Proxy
{
    public class UpcResponse : IUpcHeader
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("items")]
        public List<UpcItem> Items { get; set; }
    }
}