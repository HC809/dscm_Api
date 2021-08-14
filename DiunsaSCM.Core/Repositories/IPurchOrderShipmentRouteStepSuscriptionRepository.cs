using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Entities;

namespace DiunsaSCM.Core.Repositories
{
    public interface IPurchOrderShipmentRouteStepSuscriptionRepository : IRepositoryBase<PurchOrderShipmentRouteStepSuscription>
    {
        IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId, string userName);
        IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByUserName(string userName);
        IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByShippingRouteStepId(long shippingRouteStepId);
    }
}