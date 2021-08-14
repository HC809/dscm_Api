using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationApprovalRuleRepository : RepositoryBase<PurchQuotationApprovalRule>, IPurchQuotationApprovalRuleRepository
    {
        public PurchQuotationApprovalRuleRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
