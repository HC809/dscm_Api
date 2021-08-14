using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventItemPrepackBarcode
    {
        public long Id { get; set; }
        public decimal Qty { get; set; }

        public long InventItemId { get; set; }
        public long ItemBarcodeId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual ItemBarcode ItemBarcode { get; set; }
    }
}
