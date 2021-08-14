using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class ShippingRouteDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long? PortOfOriginId { get; set; }
        public long? PortOfDestinationId { get; set; }
        public TransportationMethod TransportationMethod { get; set; }
        public long? ShippingRouteStatusPresentationSchemaId { get; set; }

        public string PortOfOriginName { get; set; }
        public string PortOfDestinationName { get; set; }
        public string ShippingRouteStatusPresentationSchemaDescription { get; set; }

        public int TransitTimeDays { get; set; }
        public int TransitTimeHours { get; set; }
        public string TransportationMethodName { get { return TransportationMethod.ToString(); } }
        //public string TransportationMethodName { get { return ""; } }

        public ShippingRouteDTO()
        {
        }
    }
}
