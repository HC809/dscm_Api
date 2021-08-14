using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentDetailsListDataTransferObject
    {
        public long PurchOrderShipmentHeaderId { get; set; }
        public IEnumerable<PurchOrderShipmentDetailDataTransferObject> PurchOrderShipmentDetailList { get; set; }

        public PurchOrderShipmentDetailsListDataTransferObject()
        {
            
        }
    }
}
