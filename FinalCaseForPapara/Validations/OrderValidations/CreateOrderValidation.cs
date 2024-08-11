using FinalCaseForPapara.Dto.OrderDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.OrderValidations
{
    public class CreateOrderValidation : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidation()
        {
            RuleFor(c => c.CreditCardNumber)
                .Length(16)
                .WithMessage("Credit card number must be 16 digits.");

            RuleForEach(c => c.Items)
                .ChildRules(items =>
                {
                    items.RuleFor(item => item.ProductId).GreaterThan(0);
                    items.RuleFor(item => item.Quantity).GreaterThan(0);
                });
        }
    }
}
