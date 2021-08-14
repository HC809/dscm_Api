using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventItemPurchPriceLog : AuditableEntity
    {
        public long Id { get; set; }
        public decimal PurchPrice { get; set; }
        public long PurchQuotationLineId { get; set; }
        public long InventItemId { get; set; }

        public virtual PurchQuotationLine PurchQuotationLine { get; set; }
        
    }
}
