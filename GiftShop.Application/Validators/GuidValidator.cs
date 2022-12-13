using FluentValidation;

namespace GiftShop.Application.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage(String.Format(AppResource.FieldNullValidation, "Id"))
                .NotEmpty().WithMessage(String.Format(AppResource.FieldEmptyValidation, "Id"))
                .Must(ValidateGuid).WithMessage(string.Format(AppResource.GuidIdNoValid));
        }

        private bool ValidateGuid(Guid entryGuid)
        {
            return Guid.TryParse(entryGuid.ToString("D"), out var result);
        }
    }
}