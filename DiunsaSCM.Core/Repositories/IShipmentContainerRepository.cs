using System;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Repositories
{
    public interface IShipmentContainerRepository : IRepository<ShipmentContainer>
    {
        public IEnumerable<ShipmentContainer> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId);
    }
}
