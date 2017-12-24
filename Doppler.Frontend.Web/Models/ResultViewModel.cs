using System.Collections.Generic;
using Doppler.Core.Type;
using Doppler.Frontend.Web.Models.Validation;
using FluentValidation.Attributes;
using Newtonsoft.Json;

namespace Doppler.Frontend.Web.Models
{
    public class ResultViewModel
    {
        public string UpcId { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
        public int Year { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Images { get; set; }
        public string PosterPath { get; set; }
    }
}