using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;

namespace BankSlipControl.Domain.Services.v1.BankSlipService
{
    public interface IBankSlipService
    {
        public Task<BankSlip> CreateBankSlip(BankSlip bankSlip);
        public Task<BankSlip> GetBankSlipById(int id);
    }
}
