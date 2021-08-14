using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
namespace DiunsaSCM.Data
{
    public class ShipmentTypeRepository : RepositoryBase<ShipmentType>, IShipmentTypeRepository
    {
        public ShipmentTypeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}