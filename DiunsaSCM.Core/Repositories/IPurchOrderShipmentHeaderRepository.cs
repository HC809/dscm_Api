using System;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Utils;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using System.Linq;

namespace DiunsaSCM.Core.Repositories
{
    public interface IPurchOrderShipmentHeaderRepository : IRepository<PurchOrderShipmentHeader>
    {
        public IQueryable<PurchOrderShipmentHeader> All(string searchString);
        public IQueryable<PurchOrderShipmentHeader> AllWitchIncludes();
        public IQueryable<PurchOrderShipmentHeader> GetByShipmentImportId(long shipmentImportId);
    }
}
