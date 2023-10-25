namespace BankSlipControl.Domain.InputModels.v1.BankSlip
{
    public class NewBankSlipInputModel
    {
        public string PayerName { get; set; }
        public string DocumentPayer { get; set; }
        public string BeneficiaryName { get; set; }
        public string DocumentBeneficiary { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int BankId { get; set; }
    }
}
