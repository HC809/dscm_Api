using System;
using System.Collections.Generic;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class ShipmentContainerDetailRepository : Repository<ShipmentContainerDetail>, IShipmentContainerDetailRepository
    {
        public ShipmentContainerDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public IEnumerable<ShipmentContainerDetail> GetByShipmentContainerId(long shipmentContainerId)
        {
            var shipmentContainer = _context.ShipmentContainer
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.PurchOrderShipmentDetails)
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.PurchOrderHeader)
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.ShipmentImport)
                .FirstOrDefault(x => x.Id == shipmentContainerId);
            //var purchOrderShipment = _context.PurchOrderShipmentHeader.FirstOrDefault(x => x.Id == shipmentContainer.PurchOrderShipmentHeaderId);
            var purchOrderDetails = _context.PurchOrderDetail.Where(x => x.PurchOrderHeaderId == shipmentContainer.PurchOrderShipmentHeader.PurchOrderHeaderId);
            var shipmentContainerDetails = _context.ShipmentContainerDetail.Where(x => x.ShipmentContainerId == shipmentContainer.Id);

            shipmentContainerDetails = from od in purchOrderDetails
                                        join sd in shipmentContainerDetails
                                        on od.Id equals sd.PurchOrderDetailId into gj
                                        from x in gj.DefaultIfEmpty()
                                        select new ShipmentContainerDetail
                                        {
                                            Id = x.Id,
                                            ShipmentContainerId = x.ShipmentContainerId,
                                            ShipmentContainer = shipmentContainer,
                                            PurchOrderDetailId = od.Id,
                                            QtyOnContainer = x.QtyOnContainer,
                                            CreatedBy = x.CreatedBy,
                                            CreatedDate = x.CreatedDate,
                                            UpdatedBy = x.UpdatedBy,
                                            UpdatedDate = x.UpdatedDate,
                                            PurchOrderOrderDetail = od
                                        };
            return shipmentContainerDetails;
        }

    }
}
