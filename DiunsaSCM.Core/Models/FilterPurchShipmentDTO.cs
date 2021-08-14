using System;
namespace DiunsaSCM.Core.Models
{
    public class FilterPurchShipmentDTO : FilterBaseDTO
    {
        public string PurchId { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
    }   
}
