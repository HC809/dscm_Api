using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchOrderShipmentCrossDockingRepository : RepositoryBase<PurchOrderShipmentCrossDocking>, IPurchOrderShipmentCrossDockingRepository
    {
        public PurchOrderShipmentCrossDockingRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}