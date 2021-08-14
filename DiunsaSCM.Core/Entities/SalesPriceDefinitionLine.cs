using System;
namespace DiunsaSCM.Core.Entities
{
    public class SalesPriceDefinitionLine : AuditableEntity
    {
        public long Id { get; set; }
        public long? InventItemId { get; set; }
        public string InventItemCode { get; set; }
        public long? CustomerPriceGroupId { get; set; }
        public string CustomerPriceGroupCode { get; set; }
        public decimal Price { get; set; }
        public decimal EstimatedCost { get; set; }
        public long? SalesPriceId { get; set; }

        public long SalesPriceDefinitionId { get; set; }

        public virtual SalesPriceDefinition SalesPriceDefinition { get; set; }
        public virtual InventItem InventItem { get; set; }
        public virtual CustomerPriceGroup CustomerPriceGroup { get; set; }
        public virtual SalesPrice SalesPrice { get; set; }
    }
}
