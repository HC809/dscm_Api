using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class SalesPriceDTO
    {
        public long Id { get; set; }
        public decimal Price { get; set; }

        public long InventItemId { get; set; }
        public long CustomerPriceGroupId { get; set; }
        public string CustomerPriceGroupCode { get; set; }
    }
}