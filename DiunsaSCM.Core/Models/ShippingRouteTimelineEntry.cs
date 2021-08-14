using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class ShippingRouteTimelineEntry : AuditableModel
    {
        public long Id { get; set; }
        public long ShippingRouteId { get; set; }
        public long ShippingStepTypeId { get; set; }
        public int StepNumber { get; set; }

        public int EstimatedTransitTimeDays { get; set; }
        public int EstimatedTransitTimeDaysAcumulated { get; set; }

        public int RealTransitTimeDays { get; set; }
        public int RealTransitTimeDaysAcumulated { get; set; }

        public DateTime EstimatedDate { get; set; }
        public DateTime ExecutionDate { get; set; }

        public string ShippingRouteDescription { get; set; }
        public string ShippingStepTypeDescription { get; set; }
        public int Status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime RecalculatedDate { get; set; }
        public DateTime FromDateStimated { get; set; }
        public ShippingRouteStatusRisk ShippingRouteStatusRisk { get; set; }
    }
}
