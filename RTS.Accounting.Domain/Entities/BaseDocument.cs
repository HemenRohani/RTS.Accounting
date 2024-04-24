using RTS.Accounting.Domain.Common;
using RTS.Accounting.Domain.Enums;

namespace RTS.Accounting.Domain.Entities
{
    public abstract class BaseDocument : BaseEntity
    {
        public DocumentType Type { get; protected set; }
        public string Number { get; protected set; }
        public string ExternalInvoiceNumber { get; protected set; }
        public DocumentStatus Status { get; protected set; }
        public long TotalAmount { get; protected set; }
    }
}
