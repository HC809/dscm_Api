using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Entities;

namespace DiunsaSCM.Core.Repositories
{
    public interface IShipmentContainerDetailRepository : IRepository<ShipmentContainerDetail>
    {
        IEnumerable<ShipmentContainerDetail> GetByShipmentContainerId(long shipmentContainerId);
    }
}
