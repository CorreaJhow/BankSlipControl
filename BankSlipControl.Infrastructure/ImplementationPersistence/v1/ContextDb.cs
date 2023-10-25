using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1
{
    public class ContextDb : DbContext
    {
        public DbSet<BankSlip> BankSlip { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }
    }
}
