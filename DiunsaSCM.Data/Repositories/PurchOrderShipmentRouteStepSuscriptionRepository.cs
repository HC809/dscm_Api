using System.Collections.Generic;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data
{
    public class PurchOrderShipmentRouteStepSuscriptionRepository : RepositoryBase<PurchOrderShipmentRouteStepSuscription>, IPurchOrderShipmentRouteStepSuscriptionRepository
    {
        public PurchOrderShipmentRouteStepSuscriptionRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId, string userName)
        {
            var purchOrderShipmentHeader = _context.PurchOrderShipmentHeader
                .Include(x => x.PreparationShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .Include(x => x.ShippingRoute)
                .ThenInclude(x => x.ShippingRouteSteps)
                .ThenInclude(x => x.ShippingStepType)
                .FirstOrDefault(x => x.Id == purchOrderShimentHeaderId);

            var entityList = new List<PurchOrderShipmentRouteStepSuscription>();

            if (purchOrderShipmentHeader.PreparationShippingRoute != null && purchOrderShipmentHeader.PreparationShippingRoute.ShippingRouteSteps != null) {
                List<PurchOrderShipmentRouteStepSuscription> entityListPreparation = purchOrderShipmentHeader.PreparationShippingRoute.ShippingRouteSteps
                    .Select(x => new PurchOrderShipmentRouteStepSuscription
                    {
                        Id = _context.PurchOrderShipmentRouteStepSuscription
                            .Where(s => s.PurchOrderShipmentHeaderId == purchOrderShimentHeaderId && s.ShippingRouteStepId == x.Id && s.Username == userName)
                            .Select(s => s.Id)
                            .SingleOrDefault(),
                        PurchOrderShipmentHeaderId = purchOrderShimentHeaderId,
                        ShippingRouteStepId = x.Id,
                        ShippingRouteStep = x,
                        Username = userName,
                    }).ToList();

                entityList = entityList.Concat(entityListPreparation).ToList();
            }

            if (purchOrderShipmentHeader.ShippingRoute != null && purchOrderShipmentHeader.ShippingRoute.ShippingRouteSteps != null)
            {
                List<PurchOrderShipmentRouteStepSuscription> entityListShipping = purchOrderShipmentHeader.ShippingRoute.ShippingRouteSteps
                .Select(x => new PurchOrderShipmentRouteStepSuscription
                {
                    Id = _context.PurchOrderShipmentRouteStepSuscription
                        .Where(s => s.PurchOrderShipmentHeaderId == purchOrderShimentHeaderId && s.ShippingRouteStepId == x.Id && s.Username == userName)
                        .Select(s => s.Id)
                        .SingleOrDefault(),
                    PurchOrderShipmentHeaderId = purchOrderShimentHeaderId,
                    ShippingRouteStepId = x.Id,
                    ShippingRouteStep = x,
                    Username = userName,
                }).ToList();
                entityList = entityList.Concat(entityListShipping).ToList();
            }

            return entityList;
        }

        public IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByUserName(string userName)
        {
            var entityList = _context.PurchOrderShipmentRouteStepSuscription
                .Include(x => x.PurchOrderShipmentHeader)
                .ThenInclude(x=> x.PurchOrderHeader)
                .Include(x => x.ShippingRouteStep)
                .ThenInclude(x => x.ShippingStepType)
                .Where(x => x.Username == userName);

            return entityList;
        }

        public IEnumerable<PurchOrderShipmentRouteStepSuscription> GetAllByShippingRouteStepId(long shippingRouteStepId)
        {
            var entityList = _context.PurchOrderShipmentRouteStepSuscription
                .Include(x => x.PurchOrderShipmentHeader)
                .ThenInclude(x => x.PurchOrderHeader)
                .Include(x => x.ShippingRouteStep)
                .ThenInclude(x => x.ShippingStepType)
                .Where(x => x.ShippingRouteStepId == shippingRouteStepId);

            return entityList;
        }

    }
}