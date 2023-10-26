using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.Services.v1.BankSlipService;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class BankSlipService : IBankSlipService
    {
        private readonly ContextDb _context;
        public BankSlipService(ContextDb context)
        {
            _context = context;
        }

        public async Task<BankSlip> CreateBankSlip(BankSlip bankSlip)
        {
            try
            {
                var bankExist = await _context.Bank.FindAsync(bankSlip.BankId) ?? throw new Exception("There are no banks registered with this ID");
                
                var bankSlipReturn = _context.BankSlip.Add(bankSlip);

                await _context.SaveChangesAsync();

                return bankSlipReturn.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during bankslip creation process in database {ex}");
            }
        }

        public async Task<BankSlip> GetBankBillById(int id)
        {
            try
            {
                var bankSlip = await _context.BankSlip.FindAsync(id);

                return bankSlip;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during the process of getting BankSlip by ID in the database {id}", ex);
            }
        }
    }
}
