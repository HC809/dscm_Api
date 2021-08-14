using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderShipmentCrossDocking
    {
        public long Id { get; set; }
        public decimal Qty { get; set; }

        public long ShipmentContainerDetailId { get; set; }
        public long StoreId { get; set; }

        public virtual ShipmentContainerDetail ShipmentContainerDetail { get; set; }
        public virtual Store Store { get; set; }
    }
}
