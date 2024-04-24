using RTS.Accounting.Domain.Enums;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace RTS.Accounting.Domain.Entities
{
    public class IndependentCreditNote : BaseDocument
    {
        public static IndependentCreditNote Create(string number, string externalInvoiceNumber, DocumentStatus status, long totalAmount)
        {
            var entity  = new IndependentCreditNote
            {
                Number = number,
                ExternalInvoiceNumber = externalInvoiceNumber,
                Status = status,
                TotalAmount = totalAmount
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