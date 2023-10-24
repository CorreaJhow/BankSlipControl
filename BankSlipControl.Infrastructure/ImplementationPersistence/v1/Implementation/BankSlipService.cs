using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.Services.v1.Contracts;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Domain.Services.v1.Implementation
{
    public class BankSlipService : IBankSlipService
    {
        private readonly ContextDb _context;
        public BankSlipService(ContextDb context)
        {
            _context = context;
        }
        public Task<IActionResult> CreateBankBill(NewBankInputModel newBankInputModel)
        {
            throw new NotImplementedException(); 
        }

        public Task<IActionResult> GetBankBillById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
