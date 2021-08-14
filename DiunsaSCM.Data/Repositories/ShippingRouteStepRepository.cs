using System;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class ShippingRouteStepRepository : Repository<ShippingRouteStep>, IShippingRouteStepRepository
    {
        public ShippingRouteStepRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public ShippingRouteStep GetById(long id)
        {
            return _context.Set<ShippingRouteStep>()
                .Include(x => x.ShippingStepType)
                .First(x => x.Id == id);
        }
    }
}
