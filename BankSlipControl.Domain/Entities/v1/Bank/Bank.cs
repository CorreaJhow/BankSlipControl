namespace BankSlipControl.Domain.Entities.v1.Bank
{
    public class Bank
    {
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}
