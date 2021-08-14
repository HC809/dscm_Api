namespace DiunsaSCM.Core.Models
{
    public class ShippingRouteStatusPresentationSchemaDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal NoRisk { get; set; }
        public decimal LowRisk { get; set; }
        public decimal HighRisk { get; set; }
        public decimal OnTime { get; set; }
    }
}