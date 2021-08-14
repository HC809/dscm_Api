using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationLineDTO : AuditableModel
    {
        public long Id { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal PurchPrice { get; set; }
        public decimal LineAmount { get; set; }

        public long InventItemId { get; set; }
        public string InventItemCode { get; set; }
        public string InventItemDescription { get; set; }
        public string InventItemNameAlias { get; set; }
        public ItemType InventItemItemType { get; set; }
        public string InventItemItemTypeDescription { get; set; }

        public long? ItemBarcodeId { get; set; }
        public string ItemBarcodeBarcode { get; set; }
        public string ItemBarcodeDescription { get; set; }

        public long? SizeId { get; set; }
        public string SizeCode { get; set; }
        public string SizeDescription { get; set; }

        public long? ColorId { get; set; }
        public string ColorCode { get; set; }
        public string ColorDescription { get; set; }

        public long PurchQuotationId { get; set; }
    }
}