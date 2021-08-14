using System;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Repositories
{
    public interface IPurchOrderShipmentDetailRepository : IRepository<PurchOrderShipmentDetail>
    {
        IEnumerable<PurchOrderShipmentDetail> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId);
    }
}
