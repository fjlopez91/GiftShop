using FluentValidation;
using GiftShop.Application.Dtos;

namespace GiftShop.Application.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(model => model.Name)
                .NotNull().WithMessage(string.Format(AppResource.FieldNullValidation, "Name"))
                .NotEmpty().WithMessage(string.Format(AppResource.FieldEmptyValidation, "Name"))
                .MaximumLength(50).WithMessage(string.Format(AppResource.MaxLengthValidation, 50));
            RuleFor(model => model.Description)
                .MaximumLength(50).WithMessage(string.Format(AppResource.MaxLengthValidation, 100));
            RuleFor(model => model.Company)
                .NotNull().WithMessage(string.Format(AppResource.FieldNullValidation, "Company"))
                .NotEmpty().WithMessage(string.Format(AppResource.FieldEmptyValidation, "Company"))
                .MaximumLength(50).WithMessage(string.Format(AppResource.MaxLengthValidation, 50));
            RuleFor(model => model.Price)
                .NotNull().WithMessage(string.Format(AppResource.FieldNullValidation, "Price"))
                .NotEmpty().WithMessage(string.Format(AppResource.FieldEmptyValidation, "Price"));
        }
    }
}