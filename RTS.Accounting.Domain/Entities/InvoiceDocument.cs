using System.ComponentModel.DataAnnotations.Schema;

namespace RTS.Accounting.Domain.Entities
{
    public class InvoiceDocument : BaseDocument
    {
        /// not empty and  > 0
        public long TotalAmount { get; set; }
    }
}
