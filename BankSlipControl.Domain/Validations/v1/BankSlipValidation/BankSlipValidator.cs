using BankSlipControl.Domain.InputModels.v1.BankSlip;
using FluentValidation;

namespace BankSlipControl.Domain.Validations.v1.BankSlipValidation
{
    public class BankSlipValidator : AbstractValidator<BankSlipInputModel>
    {
        public BankSlipValidator()
        {
            RuleFor(p => p.PayerName).NotEmpty().WithMessage("PayerName is a required field");
            RuleFor(p => p.DocumentPayer).NotEmpty().Must(BeValidCPFOrCNPJ).WithMessage("DocumentPayer must be a valid CPF or CNPJ");
            RuleFor(p => p.BeneficiaryName).NotEmpty().WithMessage("BeneficiaryName is a required field");
            RuleFor(p => p.DocumentBeneficiary).NotEmpty().Must(BeValidCPFOrCNPJ).WithMessage("DocumentBeneficiary must be a valid CPF or CNPJ");
            RuleFor(p => p.Value).NotEmpty().GreaterThan(0).WithMessage("Value is a required field and must be greater than zero");
            RuleFor(p => p.ExpiryDate).NotEmpty().WithMessage("ExpiryDate is a required field");
            RuleFor(p => p.BankId).NotEmpty().WithMessage("BankId is a required field");
        }
        #region Documents validation
        private bool BeValidCPFOrCNPJ(string document)
        {
            return IsCPFValid(document) || IsCNPJValid(document);
        }

        public static bool IsCPFValid(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }

        public static bool IsCNPJValid(string cnpj)
        {
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
        }
        #endregion
    }
}
