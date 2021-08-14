using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class SalesPriceRepository : RepositoryBase<SalesPrice>, ISalesPriceRepository
    {
        public SalesPriceRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}