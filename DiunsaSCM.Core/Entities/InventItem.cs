using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class InventItem : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value=="" ? null : value; }
        public string Description { get; set; }
        public string NameAlias { get; set; }
        public string ItemGroupId { get; set; }
        public bool AllowDiscount { get; set; }
        public bool IsActive { get; set; }
        public ItemType ItemType { get; set; }

        public decimal GrossDepth { get; set; }
        public decimal GrossWidth { get; set; }
        public decimal GrossHeight { get; set; }
        public decimal GrossWeight { get; set; }

        public decimal Cost { get; set; }
        public decimal EstimatedCost { get; set; }
        public DateTime EstimatedCostDate { get; set; }
        public string WebSiteDescription { get; set; }
        public int WebSiteStatus { get; set; }
        public bool BlckedForSale { get; set; }
        public bool BlckedForPurch { get; set; }
        public bool BlckedForInventory { get; set; }
        public UME UME { get; set; }
        public decimal PurchPrice { get; set; }

        public long? BrandId { get; set; }
        public long? InventDimGroupId { get; set; }
        public long? InventItemGroupId { get; set; }
        public long? InventModelGroupId { get; set; }
        public long? ItemHierarchyId { get; set; }
        public long? TaxItemGroupHeadingId { get; set; }
        public long? VendorId { get; set; }
        public long? EmployeeDiscountId { get; set; }
        public long? ItemSeasonalCategoryId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual InventDimGroup InventDimGroup { get; set; }
        public virtual InventItemGroup InventItemGroup { get; set; }
        public virtual InventModelGroup InventModelGroup { get; set; }
        public virtual ItemHierarchy InventMItemHierarchyodelGroup { get; set; }
        public virtual TaxItemGroupHeading TaxItemGroupHeading { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual EmployeeDiscount EmployeeDiscount { get; set; }
        public virtual ItemSeasonalCategory ItemSeasonalCategory { get; set; }

        public virtual IList<Size> Sizes { get; set; }
        public virtual IList<Color> Colors { get; set; }
        public virtual IList<InventDim> InventDims { get; set; }
        public virtual IList<ItemBarcode> ItemBarcodes { get; set; }
        public virtual IList<InventItemStoreConfiguration> InventItemStoreConfigurations { get; set; }
        public virtual IList<UnitConvert> UnitConverts { get; set; }
        public virtual IList<InventItemPrepackBarcode> InventItemPrepackBarcodes { get; set; }

        public void ValidateWrite()
        {

        }

        public void SetPurchPrice()
        {
            decimal purchPrice = 0;
            purchPrice = InventItemPrepackBarcodes.Sum(x => x.ItemBarcode.InventItem.PurchPrice * (decimal)x.Qty);

            PurchPrice = purchPrice;
        }
    }
}
