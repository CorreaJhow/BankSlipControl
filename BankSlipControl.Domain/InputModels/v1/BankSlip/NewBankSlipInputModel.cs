﻿namespace BankSlipControl.Domain.InputModels.v1.BankSlip
{
    public class NewBankSlipInputModel
    {
        public int Id { get; set; }
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}