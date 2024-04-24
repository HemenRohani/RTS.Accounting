using RTS.Accounting.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTS.Accounting.Domain.Entities
{
    public class InvoiceDocument : BaseDocument
    {
        public ICollection<DependentCreditNote> CreditNotes { get; protected set; }

        public static InvoiceDocument Create(string number, string externalInvoiceNumber, DocumentStatus status, long totalAmount)
        {
            return new InvoiceDocument
            {
                Number = number,
                ExternalInvoiceNumber = externalInvoiceNumber,
                Status = status,
                TotalAmount = totalAmount
            };
        }
    }
}
