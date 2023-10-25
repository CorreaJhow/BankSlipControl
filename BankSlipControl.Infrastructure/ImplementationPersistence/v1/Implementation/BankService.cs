using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.Services.v1.BankContract;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class BankService : IBankService
    {
        private readonly ContextDb _context;
        public BankService(ContextDb context)
        {
            _context = context;
        }

        public Task<Bank> CreateBank(BankInputModel newBankInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bank>> GetAllBanks()
        {
            throw new NotImplementedException();
        }

        public Task<Bank> GetBankById(int code)
        {
            throw new NotImplementedException();
        }
    }
}
