using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentCrossDockingListDTO
    {
        public long ShipmentContainerId { get; set; }

        public IEnumerable<PurchOrderShipmentCrossDockingDTO> PurchOrderShipmentCrossDockingList { get; set; }

        public PurchOrderShipmentCrossDockingListDTO()
        {
        }
    }
}
