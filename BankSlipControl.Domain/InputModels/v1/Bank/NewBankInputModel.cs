namespace BankSlipControl.Domain.InputModels.v1.Bank
{
    public class NewBankInputModel
    {
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}
