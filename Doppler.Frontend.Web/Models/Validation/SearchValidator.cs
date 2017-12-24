using FluentValidation;

namespace Doppler.Frontend.Web.Models.Validation
{
    public class SearchValidator : AbstractValidator<SearchViewModel>
    {
        public SearchValidator()
        {
            RuleFor(field => field.UpcId)
                .NotNull().WithMessage("* Required")
                .NotEmpty().WithMessage("* Required")
                .Matches(@"^\d{12}").WithMessage("* Must be a 12 digit upc id");
        }
    }
}