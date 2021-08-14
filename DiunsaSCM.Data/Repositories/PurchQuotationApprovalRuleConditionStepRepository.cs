using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchQuotationApprovalRuleConditionStepRepository : RepositoryBase<PurchQuotationApprovalRuleConditionStep>, IPurchQuotationApprovalRuleConditionStepRepository
    {
        public PurchQuotationApprovalRuleConditionStepRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}