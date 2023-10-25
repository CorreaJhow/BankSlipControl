using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.Services.v1.Contracts;
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
        public Task<IActionResult> CreateBank(NewBankInputModel newBankInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAllBanks()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetBankById(int code)
        {
            throw new NotImplementedException();
        }
    }
}
