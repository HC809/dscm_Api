using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ShipmentContainerTypeRepository : Repository<ShipmentContainerType>, IShipmentContainerTypeRepository
    {
        public ShipmentContainerTypeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
