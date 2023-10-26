using BankSlipControl.Domain.Entities.v1.BankEntitie;

namespace BankSlipControl.Domain.Services.v1.BankService
{
    public interface IBankService
    {
        public Task<Bank> CreateBank(Bank newBank);
        public Task<List<Bank>> GetAllBanks();
        public Task<Bank> GetBankByCode(int code);
        public Task<Bank> GetBankById(int id);
    }
}
