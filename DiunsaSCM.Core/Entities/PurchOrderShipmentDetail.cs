using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderShipmentDetail : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public long PurchOrderDetailId { get; set; }
        public decimal QtyOnShipment { get; set; }
        public virtual PurchOrderShipmentHeader PurchOrderShipmentHeader { get; set; }
        public virtual PurchOrderDetail PurchOrderOrderDetail { get; set; }

        public virtual IEnumerable<ShipmentContainerDetail> ShipmentContainerDetails { get; set; }

        public decimal GetQtyOnShipmentContainers()
        {
            if (ShipmentContainerDetails == null)
                return 0;
            return ShipmentContainerDetails.Sum(x => x.QtyOnContainer);
        }
    }
}
