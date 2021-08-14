using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class ShippingStepType : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ShippingStepERPAction ShippingStepERPAction { get; set; }

        public ShippingStepType()
        {
        }
    }
}
