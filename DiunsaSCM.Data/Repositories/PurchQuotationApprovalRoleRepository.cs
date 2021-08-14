using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchQuotationApprovalRoleRepository : RepositoryBase<PurchQuotationApprovalRole>, IPurchQuotationApprovalRoleRepository
    {
        public PurchQuotationApprovalRoleRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}