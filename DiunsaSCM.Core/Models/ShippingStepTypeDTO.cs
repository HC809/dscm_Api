using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class ShippingStepTypeDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int TransitTimeDays { get; set; }
        public int TransitTimeHours { get; set; }

        public ShippingStepERPAction ShippingStepERPAction { get; set; }
        public string ShippingStepERPActionDescription { get; set; }

        public ShippingStepTypeDTO()
        {
        }
    }
}
