using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;

namespace RTS.Accounting.Infrastructure.EntitiesConfigs
{
    public class BaseDocumentConfigs : IEntityTypeConfiguration<BaseDocument>
    {
        public void Configure(EntityTypeBuilder<BaseDocument> builder)
        {
            builder.UseTphMappingStrategy()
                    .HasDiscriminator(x => x.Type)
                    .HasValue<InvoiceDocument>(DocumentType.InvoiceDocument)
                    .HasValue<IndependentCreditNote>(DocumentType.IndependentCreditNote)
                    .HasValue<DependentCreditNote>(DocumentType.DependentCreditNote);

            builder.Property(x => x.Number).hasc.IsRequired().HasMaxLength(10).IsUnicode(false);
            builder.Property(x => x.ExternalInvoiceNumber).IsRequired().HasMaxLength(10).IsUnicode(false);
        }
    }
}
