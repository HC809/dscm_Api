using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class SalesPriceDefinitionLineDTO
    {
        public long Id { get; set; }
        public long? InventItemId { get; set; }
        public string InventItemCode { get; set; }
        public string InventItemDescription { get; set; }
        public string InventItemNameAlias { get; set; }

        public long? CustomerPriceGroupId { get; set; }
        public string CustomerPriceGroupCode { get; set; }
        public decimal Price { get; set; }
        public decimal EstimatedCost { get; set; }
        public long? SalesPriceId { get; set; }

        public long SalesPriceDefinitionId { get; set; }
    }
}