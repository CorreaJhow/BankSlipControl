using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.Services.v1.BankService;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class BankService : IBankService
    {
        private readonly ContextDb _context;
        public BankService(ContextDb context)
        {
            _context = context;
        }

        public async Task<Bank> CreateBank(Bank newBank)
        {
            try
            {
                var bankReturn = _context.Bank.Add(newBank);

                await _context.SaveChangesAsync();

                return bankReturn.Entity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Bank could not be created.", ex);
            }
        }

        public async Task<List<Bank>> GetAllBanks()
        {
            try
            {
                var banks = await _context.Bank.ToListAsync();

                return banks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all banks", ex);
            }
        }

        public async Task<Bank> GetBankById(int id)
        {
            try
            {
                var bank = await _context.Bank.FindAsync(id);

                return bank;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting Bank by ID {id}", ex);
            }
        }
    }
}
