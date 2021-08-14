using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationApprovalRuleConditionRepository : RepositoryBase<PurchQuotationApprovalRuleCondition>, IPurchQuotationApprovalRuleConditionRepository
    {
        public PurchQuotationApprovalRuleConditionRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}