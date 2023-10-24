namespace BankSlipControl.Domain.Entities.v1
{
    public class BankSlip
    {
        public int Id { get; set; }
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; }
        public int BancoId { get; set; }
        public Bank Banco { get; set; } 
    }
}
