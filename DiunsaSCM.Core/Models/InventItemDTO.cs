using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class InventItemDTO : AuditableModel
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string NameAlias { get; set; }
        public string ItemGroupId { get; set; }
        public bool AllowDiscount { get; set; }
        public bool IsActive { get; set; }

        public ItemType ItemType { get; set; }
        public string ItemTypeDescription { get; set; }

        public decimal GrossDepth { get; set; }
        public decimal GrossWidth { get; set; }
        public decimal GrossHeight { get; set; }
        public decimal GrossWeight { get; set; }
        public string WebSiteDescription { get; set; }
        public int WebSiteStatus { get; set; }
        public bool BlckedForSale { get; set; }
        public bool BlckedForPurch { get; set; }
        public bool BlckedForInventory { get; set; }
        public decimal PurchPrice { get; set; }

        public long? BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandDescription { get; set; }

        public long? InventDimGroupId { get; set; }
        public string InventDimGroupCode { get; set; }
        public string InventDimGroupDescription { get; set; }

        public long? InventItemGroupId { get; set; }
        public string InventItemGroupCode { get; set; }
        public string InventItemGroupDescription { get; set; }

        public long? InventModelGroupId { get; set; }
        public string InventModelGroupCode { get; set; }
        public string InventModelGroupDescription { get; set; }

        public long? ItemHierarchyId { get; set; }
        public string ItemHierarchyCode { get; set; }
        public string ItemHierarchyDescription { get; set; }

        public long? TaxItemGroupHeadingId { get; set; }
        public string TaxItemGroupHeadingCode { get; set; }
        public string TaxItemGroupHeadingDescription { get; set; }

        public long? VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorDescription { get; set; }

        public long? EmployeeDiscountId { get; set; }
        public string EmployeeDiscountCode { get; set; }
        public string EmployeeDiscountDescription { get; set; }

        public long? ItemSeasonalCategoryId { get; set; }
        public string ItemSeasonalCategoryCode { get; set; }
        public string ItemSeasonalCategoryDescription { get; set; }


    }
}
