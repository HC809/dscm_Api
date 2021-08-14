using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class InventItemPrepackBarcodeDTO
    {
        public long Id { get; set; }
        public decimal Qty { get; set; }

        public long InventItemId { get; set; }

        public long ItemBarcodeId { get; set; }
        public string ItemBarcodeBarcode { get; set; }
        public string ItemBarcodeInventItemCode { get; set; }
        public string ItemBarcodeInventItemDescription { get; set; }
        public string ItemBarcodeInventItemNameAlias { get; set; }
        public decimal ItemBarcodeInventItemPurchPrice { get; set; }
        public string ItemBarcodeInventDimColorCode { get; set; }
        public string ItemBarcodeInventDimSizeCode { get; set; }

    }
}