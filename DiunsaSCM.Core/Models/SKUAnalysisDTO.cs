using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Models
{
    public class SKUAnalysisDTO : AuditableModel
    {
        public long Id { get; set; }
        public long StoreId { get; set; }
        public string StoreDescription { get; set; }
        public string Barcode { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string InventColor { get; set; }
        public string InventSize { get; set; }
        public string BarcodeSetupId { get; set; }
        public string Brand { get; set; }

        public DateTime LastPurchaseDate { get; set; }
        public string LastPurchaseYear { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ItemGroup { get; set; }

        public string OfferType { get; set; }
        public string Vendor { get; set; }

        public decimal UnitsPerRetailBoxQty { get; set; }
        public decimal UnitsPerBoxQty { get; set; }
        public decimal UnitsPerPalletQty { get; set; }
        public double Price { get; set; }
        public string G1000 { get; set; }
        public string CommercialTypology { get; set; }

        public decimal InventoryInDistributionCenterQty { get; set; }

        public decimal BackStoreLocationInventoryQty { get; set; }
        public decimal StoreLocationInventoryQty { get; set; }
        public decimal TotalStoreLocationInventoryQty { get; set; }

        public int TransferOrderedQty { get; set; }
        public int TransferInTransitQty { get; set; }
        public int TransferInReceiptQty { get; set; }

        public int TransferTotalQty { get; set; }

        public decimal InventoryCoverageRatio { get; set; }
        public double SalesQty { get; set; }

        public decimal WholesalesQty { get; set; }
        public decimal WebSalesQty { get; set; }
    }
}




