using FluentValidation;

namespace Doppler.Frontend.Web.Models.Validation
{
    public class SearchViewModelValidator : AbstractValidator<SearchViewModel>
    {
        public SearchViewModelValidator()
        {
            RuleFor(field => field.UpcId)
                .NotEmpty().WithMessage("* Required")
                .Matches(@"^\d{12}").WithMessage("* Must be a 12 digit UPC number")
                .Length(12).WithMessage("* Must be a 12 digit UPC number");
        }
    }
}