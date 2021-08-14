using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemEnrolmentRepository : RepositoryBase<InventItemEnrolment>, IInventItemEnrolmentRepository
    {
        public InventItemEnrolmentRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}