using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchOrderShipmentRouteStepSuscriptionService : IServiceBase<PurchOrderShipmentRouteStepSuscriptionDTO>
    {
        public ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId, string userName);
        public ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>> GetAllByUserName(string userName);

    }
}