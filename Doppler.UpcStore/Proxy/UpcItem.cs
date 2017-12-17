using System.Collections.Generic;
using Newtonsoft.Json;

namespace Doppler.UpcStore.Proxy
{
    public class UpcItem
    {
        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("lowest_recorded_price")]
        public decimal LowestRecordedPrice { get; set; }

        [JsonProperty("highest_recorded_price")]
        public decimal HighestRecordedPrice { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }
    }
}