using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Z.EntityFramework.Plus;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchOrderShipmentDetailRepository : Repository<PurchOrderShipmentDetail>, IPurchOrderShipmentDetailRepository
    {
        public PurchOrderShipmentDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public IEnumerable<PurchOrderShipmentDetail> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId)
        {
            var purchOrderShipmentHeader = _context.PurchOrderShipmentHeader
                .Include(x => x.ShipmentImport)
                .FirstOrDefault(x => x.Id == purchOrderShipmentHeaderId);
            var purchOrderDetails = _context.PurchOrderDetail.Where(x => x.PurchOrderHeaderId == purchOrderShipmentHeader.PurchOrderHeaderId);
            var purchOrderShipmentDetails = _context.PurchOrderShipmentDetail.Where(x => x.PurchOrderShipmentHeaderId == purchOrderShipmentHeader.Id);
            purchOrderShipmentDetails = from od in purchOrderDetails
                                        join sd in purchOrderShipmentDetails
                                        on od.Id equals sd.PurchOrderDetailId into gj
                                        from x in gj.DefaultIfEmpty()
                                        select new PurchOrderShipmentDetail
                                        {
                                            Id = x.Id,
                                            PurchOrderShipmentHeaderId = x.PurchOrderShipmentHeaderId,
                                            PurchOrderShipmentHeader = purchOrderShipmentHeader,
                                            PurchOrderDetailId = od.Id,
                                            QtyOnShipment = x.QtyOnShipment,
                                            CreatedBy = x.CreatedBy,
                                            CreatedDate = x.CreatedDate,
                                            UpdatedBy = x.UpdatedBy,
                                            UpdatedDate = x.UpdatedDate,
                                            PurchOrderOrderDetail = od,
                                            ShipmentContainerDetails = _context.ShipmentContainerDetail.Where(c => c.ShipmentContainer.PurchOrderShipmentHeaderId == purchOrderShipmentHeaderId && c.PurchOrderDetailId == od.Id).ToList(),
                                        };
            return purchOrderShipmentDetails;
        }
    }
}
