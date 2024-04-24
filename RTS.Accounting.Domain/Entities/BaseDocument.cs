using RTS.Accounting.Domain.Common;
using RTS.Accounting.Domain.Enums;

namespace RTS.Accounting.Domain.Entities
{
    public abstract class BaseDocument : BaseEntity
    {
        public DocumentType Type { get; set; }
        public string Number { get; set; }
        /// not empty and 10 char
        public string ExternalInvoiceNumber { get; set; }
        public DocumentStatus Status { get; set; }

    }
}
