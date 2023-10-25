using BankSlipControl.Domain.InputModels.v1.Bank;
using FluentValidation;

namespace BankSlipControl.Domain.Validations.v1.BankValidation
{
    public class BankValidator : AbstractValidator<BankInputModel>
    {
        public BankValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is a required field");
            RuleFor(b => b.Code).NotEmpty().Length(3).Must(BeValidBankCode).WithMessage("The bank code is a mandatory field and must be a sequence of three numeric digits");
            RuleFor(p => p.InterestPercentage).NotEmpty().WithMessage("InterestPercentage is a required field");
        }

        private static bool BeValidBankCode(string code)
        {
            return code.All(char.IsDigit);
        }
    }
}
