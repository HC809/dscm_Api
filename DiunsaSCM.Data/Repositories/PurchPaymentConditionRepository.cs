using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchPaymentConditionRepository : RepositoryBase<PurchPaymentCondition>, IPurchPaymentConditionRepository
    {
        public PurchPaymentConditionRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}