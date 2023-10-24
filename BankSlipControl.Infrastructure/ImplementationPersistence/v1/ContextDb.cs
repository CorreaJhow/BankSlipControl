using BankSlipControl.Domain.Entities.v1;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1
{
    public class ContextDb : DbContext
    {
        public DbSet<BankSlip> Boletos { get; set; }
        public DbSet<Bank> Bancos { get; set; }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }
    }
}
