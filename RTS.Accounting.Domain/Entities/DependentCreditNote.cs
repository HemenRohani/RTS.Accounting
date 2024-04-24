using RTS.Accounting.Domain.Enums;
using System.Text.RegularExpressions;

namespace RTS.Accounting.Domain.Entities
{
    public class DependentCreditNote : BaseDocument
    {
        public int ParentInvoiceId { get; set; }
        public InvoiceDocument ParentInvoice { get; set; }

        public static DependentCreditNote Create(string number, string externalInvoiceNumber, DocumentStatus status, long totalAmount, int parentInvoiceId)
        {
            var entity = new DependentCreditNote
            {
                Number = number,
                ExternalInvoiceNumber = externalInvoiceNumber,
                Status = status,
                TotalAmount = totalAmount,
                ParentInvoiceId = parentInvoiceId
            };
            entity.Validate();
            return entity;

        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Number) || !Regex.IsMatch(Number, "^\\d{10}$"))
                throw new ArgumentOutOfRangeException(nameof(Number));

            if (string.IsNullOrWhiteSpace(ExternalInvoiceNumber) || !Regex.IsMatch(ExternalInvoiceNumber, "^\\w{10}$"))
                throw new ArgumentOutOfRangeException(nameof(ExternalInvoiceNumber));

            if (TotalAmount >= 0)
                throw new ArgumentOutOfRangeException(nameof(TotalAmount));
        }
    }
}
