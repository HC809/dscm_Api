using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationApprovalRuleConditionTermRepository : RepositoryBase<PurchQuotationApprovalRuleConditionTerm>, IPurchQuotationApprovalRuleConditionTermRepository
    {
        public PurchQuotationApprovalRuleConditionTermRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}