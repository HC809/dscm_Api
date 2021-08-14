using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ShippingRouteRepository : Repository<ShippingRoute>, IShippingRouteRepository
    {
        public ShippingRouteRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
