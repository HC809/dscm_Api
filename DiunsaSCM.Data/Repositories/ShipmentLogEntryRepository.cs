using System;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class ShipmentLogEntryRepository : Repository<ShipmentLogEntry>, IShipmentLogEntryRepository
    {
        public ShipmentLogEntryRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public ShipmentLogEntry GetById(long id)
        {
            return _context.Set<ShipmentLogEntry>()
                .Include(x => x.PurchOrderShipmentHeader)
                .ThenInclude(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRouteStep)
                .ThenInclude(x => x.ShippingStepType)
                .First(x => x.Id == id);
        }
    }
}
