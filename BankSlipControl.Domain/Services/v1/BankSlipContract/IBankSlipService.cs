using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.BankSlip;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Domain.Services.v1.BankSlipContract
{
    public interface IBankSlipService
    {
        public Task<IActionResult> CreateBankSlip(BankSlip newBankSlip);
        public Task<IActionResult> GetBankBillById(int id);
    }
}
