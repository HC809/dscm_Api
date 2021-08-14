using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ShipmentImportRepository : RepositoryBase<ShipmentImport>, IShipmentImportRepository
    {
        public ShipmentImportRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
