using FinalCaseForPapara.Dto.UserDTOs;
using FluentValidation;

namespace FinalCaseForPapara.Validations.UserValidations
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .Length(10, 50).WithMessage("Email must be between 10 - 50 characters.")
                .EmailAddress().WithMessage("Please enter a valid mail address.");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(5, 16).WithMessage("Password must be between 5 - 16 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one number.")
                .Matches(@"[!@#$%^&*(),.?:{}|<>]").WithMessage("Password must contain at least one special character.");
        }
    }
}
