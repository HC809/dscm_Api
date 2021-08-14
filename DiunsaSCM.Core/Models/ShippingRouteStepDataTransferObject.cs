using System;
namespace DiunsaSCM.Core.Models
{
    public class ShippingRouteStepDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public long ShippingRouteId { get; set; }
        public long ShippingStepTypeId { get; set; }
        public int StepNumber { get; set; }
        public int TransitTimeDays { get; set; }
        public int TransitTimeHours { get; set; }

        public string ShippingStepTypeDescription { get; set; }
        
        public ShippingRouteStepDataTransferObject()
        {
        }
    }
}
