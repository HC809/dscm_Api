using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemPurchPriceLogRepository : RepositoryBase<InventItemPurchPriceLog>, IInventItemPurchPriceLogRepository
    {
        public InventItemPurchPriceLogRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}