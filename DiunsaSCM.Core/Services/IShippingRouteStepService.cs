using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShippingRouteStepService
    {
        ServiceResult<ShippingRouteStepDataTransferObject> Add(ShippingRouteStepDataTransferObject model);
        ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>> GetAll();
        ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>> GetAllByShippingRoute(long shippingRouteId);
       
        ServiceResult<ShippingRouteStepDataTransferObject> GetById(long id);
        ServiceResult<ShippingRouteStepDataTransferObject> Delete(long id);
        ServiceResult<ShippingRouteStepDataTransferObject> Update(ShippingRouteStepDataTransferObject model);
    }
}
