using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiunsaSCM.Core.Entities
{
    public class ShippingRoute : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long? PortOfOriginId { get; set; }
        public long? PortOfDestinationId { get; set; }
        public int TransportationMethod { get; set; }
        public long? ShippingRouteStatusPresentationSchemaId { get; set; }

        public virtual ShippingRouteStatusPresentationSchema ShippingRouteStatusPresentationSchema { get; set; }
        [ForeignKey("PortOfOriginId")]
        public virtual Port PortOfOrigin { get; set; }
        [ForeignKey("PortOfDestinationId")]
        public virtual Port PortOfDestination { get; set; }

        public virtual IEnumerable<ShippingRouteStep> ShippingRouteSteps { get; set; }

        public ShippingRoute()
        {
        }

        public int GetTransitTimeDays()
        {
            if (ShippingRouteSteps == null)
                return 0;
            return ShippingRouteSteps.Sum(x => x.TransitTimeDays);
        }
        public int GetTransitTimeHours()
        {
            if (ShippingRouteSteps == null)
                return 0;
            return ShippingRouteSteps.Sum(x => x.TransitTimeHours);
        }

    }
}
