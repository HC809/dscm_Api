using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class ShipmentContainerRepository : Repository<ShipmentContainer>, IShipmentContainerRepository
    {
        public ShipmentContainerRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public IEnumerable<ShipmentContainer> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId)
        {
            return _context.ShipmentContainer.Include(x => x.ShipmentContainerType).Where(x => x.PurchOrderShipmentHeaderId == purchOrderShipmentHeaderId);
        }

        public new IQueryable<ShipmentContainer> All()
        {
            return _context.Set<ShipmentContainer>().Include(x => x.ShipmentContainerType);
        }
    }
}
