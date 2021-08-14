using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchRoleRepository : RepositoryBase<PurchRole>, IPurchRoleRepository
    {
        public PurchRoleRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}