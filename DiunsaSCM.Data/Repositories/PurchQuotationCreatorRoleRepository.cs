using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchQuotationCreatorRoleRepository : RepositoryBase<PurchQuotationCreatorRole>, IPurchQuotationCreatorRoleRepository
    {
        public PurchQuotationCreatorRoleRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}