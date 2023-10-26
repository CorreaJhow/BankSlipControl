using BankSlipControl.Domain.InputModels.v1.User;
using FluentValidation;

namespace BankSlipControl.Domain.Validations.v1.UserValidation
{
    public class UserValidator : AbstractValidator<UserInputModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Login).NotEmpty().WithMessage("Login is a required field")
           .Length(3, 50).WithMessage("Login must be between 3 and 50 characters");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Email is a required field");

            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is a required field")
            .MinimumLength(3).WithMessage("The password must be at least 3 characters long");
        }
    }
}
