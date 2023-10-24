using BankSlipControl.Domain.InputModels.v1.Bank;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Domain.Services.v1.Contracts
{
    public interface IBankSlipService
    {
        public Task<IActionResult> CreateBankBill(NewBankInputModel newBankInputModel);
        public Task<IActionResult> GetBankBillById(int id);
    }
}
