using System;
namespace DiunsaSCM.Core.Entities
{
    public class SalesPrice
    {
        public long Id { get; set; }
        public decimal Price { get; set; }

        public long InventItemId { get; set; }
        public long CustomerPriceGroupId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual CustomerPriceGroup CustomerPriceGroup { get; set; }
    }
}
