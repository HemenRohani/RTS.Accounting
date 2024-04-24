using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Application.Dtos
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string ExternalInvoiceNumber { get; set; }
        public string Status { get; set; }
        public long TotalAmount { get; set; }

        internal static DocumentDto Map(BaseDocument document)
        {
            return new DocumentDto
            {
                Id = document.Id,
                Type = document.Type.ToString(),
                Number = document.Number,
                ExternalInvoiceNumber = document.ExternalInvoiceNumber,
                Status = document.Status.ToString(),
                TotalAmount = document.TotalAmount
            };
        }
    }
}
