using Microsoft.EntityFrameworkCore;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Infrastructure.EntitiesConfigs;

namespace RTS.Accounting.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<BaseDocument> BaseDocuments { get; set; }
        public DbSet<InvoiceDocument> InvoiceDocument { get; set; }
        public DbSet<IndependentCreditNote> IndependentDocuments { get; set; }
        public DbSet<DependentCreditNote> DependentCreditNote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseDocumentConfigs());
        }
    }
}
