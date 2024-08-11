using FinalCaseForPapara.Dto.UserDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.UserValidations
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(3, 45).WithMessage("First name must be between 3 - 45 characters.");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 50).WithMessage("Last name must be between 2 - 50 characters.");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .Length(10, 50).WithMessage("Email must be between 10 - 50 characters.")
                .EmailAddress().WithMessage("Please enter a valid mail address.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(5, 16).WithMessage("Password must be between 5 - 16 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one number.")
                .Matches(@"[!@#$%^&*(),.?:{}|<>]").WithMessage("Password must contain at least one special character.");
        }
    }
}
