using System.Collections.Generic;
using Doppler.Core.Type;
using Doppler.Frontend.Web.Models.Validation;
using FluentValidation.Attributes;
using Newtonsoft.Json;

namespace Doppler.Frontend.Web.Models
{
    public class ResultViewModel
    {
        [JsonProperty("upcId")]
        public string UpcId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("mediaType")]
        public MediaType MediaType { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("cast")]
        public List<string> Cast { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("posterPath")]
        public string PosterPath { get; set; }
    }
}