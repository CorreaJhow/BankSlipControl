using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;

namespace BankSlipControl.Domain.Services.v1.BankSlipContract
{
    public interface IBankSlipService
    {
        public Task<BankSlip> CreateBankSlip(BankSlip bankSlip);
        public Task<BankSlip> GetBankBillById(int id);
    }
}
