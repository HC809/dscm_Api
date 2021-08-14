using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShippingRouteService
    {
        ServiceResult<ShippingRouteDTO> Add(ShippingRouteDTO model);
        ServiceResult<IEnumerable<ShippingRouteDTO>> GetAll();
        ServiceResult<ShippingRouteDTO> GetById(long id);
        ServiceResult<ShippingRouteDTO> Delete(long id);
        ServiceResult<ShippingRouteDTO> Update(ShippingRouteDTO model);
    }
}
