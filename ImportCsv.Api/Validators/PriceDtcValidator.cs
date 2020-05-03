using FluentValidation;
using FluentValidation.Results;
using ImportCsv.Api.Contracts;
using ImportCsv.Api.Exceptions;
using System.Linq;

namespace ImportCsv.Api.src.Validators
{
    public class PriceDtcValidator : AbstractValidator<PriceDtc>
    {
        public PriceDtcValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.AmountPrice).NotNull().GreaterThan(0);
        }

        public override ValidationResult Validate(ValidationContext<PriceDtc> context)
        {
            var validatorResult = base.Validate(context);
            if (!validatorResult.IsValid)
            {
                throw new InvalidRequestExpection(validatorResult.Errors.Select(x => x.ErrorMessage)?.ToList());
            }
            return validatorResult;
        }
    }
}