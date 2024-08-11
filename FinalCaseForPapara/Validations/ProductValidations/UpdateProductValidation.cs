using FinalCaseForPapara.Dto.ProductDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.ProductValidations
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 20).WithMessage("Name must be between 2 - 20 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 100).WithMessage("Description must be between 5 - 100 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is required.")
                .InclusiveBetween(50, 200000).WithMessage("Price must be between 50 - 200000");

            RuleFor(p => p.PointsPercentage)
                .NotEmpty().WithMessage("Points percentage is required.")
                .InclusiveBetween(1, 20).WithMessage("Points percentage must be between 1 - 20");

            RuleFor(p => p.MaxPoints)
                .NotEmpty().WithMessage("Max points is required.")
                .InclusiveBetween(10, 1000).WithMessage("Max points must be between 10 - 1000");

            RuleFor(p => p.Stock)
                .NotEmpty().WithMessage("Stock is required.");

            RuleFor(p => p.IsActive)
                .NotEmpty().WithMessage("Is Active is required.");

            RuleFor(p => p.CategoryIds)
                .NotEmpty().WithMessage("CategoryIds is required.")
                .Must(categoryIds => categoryIds.All(id => id > 0)).WithMessage("All category IDs must be greater than 0")
                .Must(categoryIds => categoryIds.Distinct().Count() == categoryIds.Count).WithMessage("Duplicate category IDs are not allowed.");
        }
    }
}
