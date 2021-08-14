using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class ShipmentContainerType : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal CubicCapacity { get; set; }
        public decimal LoadCapacity { get; set; }

        public ShipmentContainerType()
        {
        }
    }
}
