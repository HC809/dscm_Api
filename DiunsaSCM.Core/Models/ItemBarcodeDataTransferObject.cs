using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class ItemBarcodeDTO
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string ERPVariantCode { get; set; }

        public string SearchText { get { return Barcode + " - "+ InventItemCode + " - "+ InventItemNameAlias + " - " + InventItemDescription; } }

        public long InventItemId { get; set; }
        public string InventItemCode { get; set; }
        public string InventItemDescription { get; set; }
        public string InventItemNameAlias { get; set; }
        public ItemType InventItemItemType { get; set; }
        public decimal InventItemPurchPrice { get; set; }

        public long? InventDimId { get; set; }
        public string InventDimDescription { get; set; }

        public long? InventDimColorId { get; set; }
        public string InventDimColorCode { get; set; }

        public long? InventDimSizeId { get; set; }
        public string InventDimSizeCode { get; set; }

        public long? InventItemVendorId { get; set; }
        public string InventItemVendorCode { get; set; }
        public string InventItemVendorDescription { get; set; }


    }
}
