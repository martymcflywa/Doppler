using System.ComponentModel.DataAnnotations;
using Doppler.Frontend.Web.Models.Validation;
using FluentValidation.Attributes;
using Newtonsoft.Json;

namespace Doppler.Frontend.Web.Models
{
    [Validator(typeof(SearchViewModelValidator))]
    public class SearchViewModel
    {
        [Display(Name = "UPC Search")]
        [DataType(DataType.Text)]
        [JsonProperty("upcId")]
        public string UpcId { get; set; }
    }
}