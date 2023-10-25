using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;

namespace BankSlipControl.Domain.Services.v1.BankContract
{
    public interface IBankService
    {
        public Task<Bank> CreateBank(Bank newBank);
        public Task<List<Bank>> GetAllBanks();
        public Task<Bank> GetBankById(int id);

    }
}
