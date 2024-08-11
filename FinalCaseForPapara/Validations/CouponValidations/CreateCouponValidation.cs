using FinalCaseForPapara.Dto.CouponDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.CouponValidations
{
    public class CreateCouponValidation : AbstractValidator<CreateCouponDto>
    {
        public CreateCouponValidation() 
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(3, 10).WithMessage("Code must be between 3 - 10 characters.");

            RuleFor(c => c.DiscountAmount)
                .NotEmpty().WithMessage("Discount amount is required.")
                .InclusiveBetween(50, 5000).WithMessage("Discount amount must be between 50 - 5000");

            RuleFor(c => c.ExpiryDate)
                .NotEmpty().WithMessage("Expiry date is required");
        }
    }
}
