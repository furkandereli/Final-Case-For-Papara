using FinalCaseForPapara.Dto.OrderDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations
{
    public class CreditCardValidation : AbstractValidator<CreateOrderDto>
    {
        public CreditCardValidation()
        {
            //RuleFor(c => c.CreditCardNumber)
            //    .CreditCard()
            //    .WithMessage("Invalid credit card number");

            RuleForEach(c => c.Items)
                .ChildRules(items =>
                {
                    items.RuleFor(item => item.ProductId).GreaterThan(0);
                    items.RuleFor(item => item.Quantity).GreaterThan(0);
                });
        }
    }
}
