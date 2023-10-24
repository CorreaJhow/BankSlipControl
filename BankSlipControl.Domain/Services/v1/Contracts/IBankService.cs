using BankSlipControl.Domain.InputModels.v1.Bank;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Domain.Services.v1.Contracts
{
    public interface IBankService
    {
        public Task<IActionResult> CreateBank(NewBankInputModel newBankInputModel);

        public Task<IActionResult> GetAllBanks();

        public Task<IActionResult> GetBankById(int code);
        
    }
}
