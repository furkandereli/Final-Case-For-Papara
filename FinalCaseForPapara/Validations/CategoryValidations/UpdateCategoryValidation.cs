using FinalCaseForPapara.Dto.CategoryDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.CategoryValidations
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 20).WithMessage("Name must be between 2 - 20 characters.");

            RuleFor(c => c.Url)
                .NotEmpty().WithMessage("Url is required")
                .Length(2, 10).WithMessage("URL must be between 2 - 10 characters.");

            RuleFor(c => c.Tag)
                .NotEmpty().WithMessage("Tag is required")
                .Length(2, 10).WithMessage("Tag must be between 2 - 10 characters.");
        }
    }
}
