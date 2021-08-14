using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchOrderShipmentCrossDockingService : IServiceBase<PurchOrderShipmentCrossDockingDTO>
    {
        Task<ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>> GetAllByShipmentContainerId(long parentId, string searchString = "", int slice = 0);
        Task<ServiceResult<PurchOrderShipmentCrossDockingListDTO>> AddList(PurchOrderShipmentCrossDockingListDTO modelList);
    }
}