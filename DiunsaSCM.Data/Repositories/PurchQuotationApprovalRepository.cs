using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationApprovalRepository : RepositoryBase<PurchQuotationApproval>, IPurchQuotationApprovalRepository
    {
        public PurchQuotationApprovalRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}