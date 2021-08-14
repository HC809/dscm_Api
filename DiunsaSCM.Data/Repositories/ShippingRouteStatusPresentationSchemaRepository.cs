using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class ShippingRouteStatusPresentationSchemaRepository : RepositoryBase<ShippingRouteStatusPresentationSchema>, IShippingRouteStatusPresentationSchemaRepository
    {
        public ShippingRouteStatusPresentationSchemaRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}