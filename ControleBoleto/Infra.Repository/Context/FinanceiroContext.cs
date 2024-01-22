using Domain.Entities;
using Domain.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Context
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoletoMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
        }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
    }
}
