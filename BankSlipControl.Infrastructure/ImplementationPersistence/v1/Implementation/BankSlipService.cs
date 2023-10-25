using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.InputModels.v1.BankSlip;
using BankSlipControl.Domain.Services.v1.BankSlipContract;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class BankSlipService : IBankSlipService
    {
        private readonly ContextDb _context;
        public BankSlipService(ContextDb context)
        {
            _context = context;
        }

        public Task<IActionResult> CreateBankSlip(BankSlip newBankSlip)
        {
            //mapear utilizando auto mapper NewBankSlipInputModel para BankSlip
            throw new NotImplementedException();

        }

        public Task<IActionResult> GetBankBillById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
