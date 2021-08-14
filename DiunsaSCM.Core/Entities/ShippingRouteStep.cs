using System;
namespace DiunsaSCM.Core.Entities
{
    public class ShippingRouteStep : AuditableEntity
    {
        public long Id { get; set; }
        public long ShippingRouteId { get; set; }
        public long ShippingStepTypeId { get; set; }
        public int StepNumber { get; set; }
        public int TransitTimeDays { get; set; }
        public int TransitTimeHours { get; set; }

        public virtual ShippingRoute ShippingRoute { get; set; }
        public virtual ShippingStepType ShippingStepType { get; set; }

        public ShippingRouteStep()
        {
        }
    }
}
