using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class ShipmentContainerDetailsListDataTransferObject
    {
        public long ShipmentContainerId { get; set; }
        public long PurchOrderDetailId { get; set; }

        public IEnumerable<ShipmentContainerDetailDataTransferObject> ShipmentContainerDetailList { get; set; }

        public ShipmentContainerDetailsListDataTransferObject()
        {
        }
    }
}
