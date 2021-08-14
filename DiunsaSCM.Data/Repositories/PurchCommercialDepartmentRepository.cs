using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchCommercialDepartmentRepository : RepositoryBase<PurchCommercialDepartment>, IPurchCommercialDepartmentRepository
    {
        public PurchCommercialDepartmentRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}