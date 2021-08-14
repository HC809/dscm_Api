using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShippingRouteTimelineEntryService
    {
        ServiceResult<IEnumerable<ShippingRouteTimelineEntry>> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId);
    }
}
