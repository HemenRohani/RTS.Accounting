using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Infrastructure.EntitiesConfigs
{
    internal class DependentCreditNoteConfigs : IEntityTypeConfiguration<DependentCreditNote>
    {
        public void Configure(EntityTypeBuilder<DependentCreditNote> builder)
        {
            builder.HasOne(x => x.ParentInvoice).WithMany(x => x.CreditNotes).HasForeignKey(x => x.ParentInvoiceId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
