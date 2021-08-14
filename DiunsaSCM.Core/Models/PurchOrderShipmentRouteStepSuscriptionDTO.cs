namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentRouteStepSuscriptionDTO : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public long ShippingRouteStepId { get; set; }
        public string Username { get; set; }
        public string PurchOrderShipmentHeaderDescription { get; set; }
        public string ShippingRouteStepDescription { get; set; }

        public string PurchId { get; set; }
        public string PurchName { get; set; }
    }
}