using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using DiunsaSCM.Utils;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchOrderShipmentHeaderRepository : Repository<PurchOrderShipmentHeader>, IPurchOrderShipmentHeaderRepository
    {
        public PurchOrderShipmentHeaderRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public PurchOrderShipmentHeader GetById(long id)
        {
            return _context.Set<PurchOrderShipmentHeader>()
                .Include(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.PreparationShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.ShipmentImport)
                .Include(x => x.ShipmentLogEntries)
                .ThenInclude(x => x.ShippingRouteStep)
                .Include(x => x.ShipmentType)
                .First(x => x.Id == id);
        }

        public IQueryable<PurchOrderShipmentHeader> All(string searchString)
        {
            return _context.Set<PurchOrderShipmentHeader>()
                .Include(x => x.PurchOrderHeader)
                .Include(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.PreparationShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.ShipmentImport)
                .Include(x => x.ShipmentLogEntries)
                .ThenInclude(x => x.ShippingRouteStep)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.ShipmentContainers)
                .Include(x => x.ShippingCompany)
                .Include(x => x.ShipmentType)
                .Where(x => String.IsNullOrEmpty(searchString)
                    || (x.PurchOrderHeader.Code+"-"+x.Code).Contains(searchString)
                    || x.PurchOrderHeader.Code.Contains(searchString)
                    || x.PurchOrderHeader.VendorAccount.Contains(searchString)
                    || x.PurchOrderHeader.PurchName.Contains(searchString)
                    || x.ShipmentImport.BLNumber.Contains(searchString)
                    || x.Description.Contains(searchString)
                    || x.ShippingCompany.Name.Contains(searchString));
        }

        public IQueryable<PurchOrderShipmentHeader> AllWitchIncludes()
        {
            return _context.Set<PurchOrderShipmentHeader>()
                .Include(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.PreparationShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.ShipmentImport)
                .Include(x => x.ShipmentLogEntries)
                .ThenInclude(x => x.ShippingRouteStep)
                .Include(x => x.ShipmentContainers);
        }

        public IQueryable<PurchOrderShipmentHeader> GetByShipmentImportId(long shipmentImportId) {
            return _context.Set<PurchOrderShipmentHeader>()
                .Where(x => x.ShipmentImportId == shipmentImportId)
                .Include(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRoute)
                .Include(x => x.ShipmentImport)
                .Include(x => x.PreparationShippingRoute)
                .Include(x => x.ShipmentLogEntries)
                .ThenInclude(x => x.ShippingRouteStep)
                .Include(x => x.ShipmentContainers);
        }



    }
}
