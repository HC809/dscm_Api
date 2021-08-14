using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationApprovalLogRepository : RepositoryBase<PurchQuotationApprovalLog>, IPurchQuotationApprovalLogRepository
    {
        public PurchQuotationApprovalLogRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
