using System.ComponentModel.DataAnnotations;
using Doppler.Frontend.Web.Models.Validation;
using FluentValidation.Attributes;

namespace Doppler.Frontend.Web.Models
{
    [Validator(typeof(SearchValidator))]
    public class SearchViewModel
    {
        [Display(Name = "Upc Id")]
        [DataType(DataType.Text)]
        public string UpcId { get; set; }
    }
}