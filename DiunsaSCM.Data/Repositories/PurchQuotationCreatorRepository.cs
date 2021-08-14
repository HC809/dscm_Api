using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchQuotationCreatorRepository : RepositoryBase<PurchQuotationCreator>, IPurchQuotationCreatorRepository
    {
        public PurchQuotationCreatorRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}