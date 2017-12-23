using System.ComponentModel.DataAnnotations;
using Doppler.Frontend.Web.Models.Validation;
using FluentValidation.Attributes;
using Newtonsoft.Json;

namespace Doppler.Frontend.Web.Models
{
    [Validator(typeof(SearchValidator))]
    public class SearchViewModel
    {
        [Display(Name = "Upc Id")]
        [DataType(DataType.Text)]
        [JsonProperty("upcId")]
        public string UpcId { get; set; }
    }
}