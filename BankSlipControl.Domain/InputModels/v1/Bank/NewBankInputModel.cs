namespace BankSlipControl.Domain.InputModels.v1.Bank
{
    public class NewBankInputModel
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public decimal interestPercentage { get; set; }
    }
}
