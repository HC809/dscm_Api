using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchOrderDetailRepository : RepositoryBase<PurchOrderDetail>, IPurchOrderDetailRepository
    {
        public PurchOrderDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}

/*

using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchOrderDetailRepository : Repository<PurchOrderDetail>, IPurchOrderDetailRepository 
    {
        public PurchOrderDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        public IEnumerable<PurchOrderDetail> GetByPurchOrderHeaderId(long purchOrderHeaderId) {
            return _context.PurchOrderDetail.Where(x => x.PurchOrderHeaderId == purchOrderHeaderId).Include(x => x.PurchOrderShipmentDetails).Include(x=> x.ShipmentContainerDetails);
        }

        public PurchOrderDetail GetById(long purchOrderDetailId)
        {
            return _context.PurchOrderDetail
                .Include(x => x.PurchOrderShipmentDetails)
                .Include(x => x.ShipmentContainerDetails)
                .FirstOrDefault(x => x.Id == purchOrderDetailId);
        }

    }
}
*/