using System;
using System.ComponentModel.DataAnnotations;

namespace DiunsaSCM.Core.Entities
{
    public class ShipmentContainerDetail : AuditableEntity
    {
        public long Id { get; set; }
        public long ShipmentContainerId { get; set; }
        public long PurchOrderDetailId { get; set; }
        public decimal QtyOnContainer { get; set; }
        public virtual ShipmentContainer ShipmentContainer { get; set; }
        public virtual PurchOrderDetail PurchOrderOrderDetail { get; set; }

        public ShipmentContainerDetail()
        {
            
        }

        public decimal GetQtyOnShipment()
        {
            if (ShipmentContainer == null || ShipmentContainer.PurchOrderShipmentHeader == null)
                return 0;

            decimal qtyOnShipment = 0;
            foreach (PurchOrderShipmentDetail purchOrderShipmentDetail in ShipmentContainer.PurchOrderShipmentHeader.PurchOrderShipmentDetails)
            {
                if(purchOrderShipmentDetail.PurchOrderDetailId == PurchOrderDetailId)
                {
                    qtyOnShipment += purchOrderShipmentDetail.QtyOnShipment;
                }
            }
            return qtyOnShipment;
        }
    }
}
