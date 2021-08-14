using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationLineRepository : RepositoryBase<PurchQuotationLine>, IPurchQuotationLineRepository
    {
        public PurchQuotationLineRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}