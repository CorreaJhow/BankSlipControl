namespace BankSlipControl.Domain.InputModels.v1.Bank
{
    public class BankInputModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal InterestPercentage { get; set; }
    }
}
