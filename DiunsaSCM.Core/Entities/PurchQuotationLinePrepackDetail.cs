using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationLinePrepackDetail
    {
        public long Id { get; set; }
        
        public long PurchQuotationLineId { get; set; }

        public decimal QtyPerPrepack { get; set; }
        public decimal PurchPrice { get; set; }

        public long InventItemId { get; set; }
        public long? ItemBarcodeId { get; set; }
        public long? SizeId { get; set; }
        public long? ColorId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual ItemBarcode ItemBarcode { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual PurchQuotationLine PurchQuotationLine { get; set; }


        public decimal GetQtyPrepackOrdered()
        {
            if (PurchQuotationLine != null)
            {
                return PurchQuotationLine.QtyOrdered;
            }
            return 0;
        }
        public decimal GetQtyOrdered()
        {
            if (PurchQuotationLine != null)
            {
                return PurchQuotationLine.QtyOrdered * this.QtyPerPrepack;
            }
            return 0;
        }

        public decimal GetLineAmount()
        {
            if (PurchQuotationLine != null)
            {
                return PurchQuotationLine.QtyOrdered * this.QtyPerPrepack * this.PurchPrice;
            }
            return 0;
        }
    }
}
