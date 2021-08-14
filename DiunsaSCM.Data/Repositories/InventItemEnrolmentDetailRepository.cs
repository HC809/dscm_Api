using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemEnrolmentDetailRepository : RepositoryBase<InventItemEnrolmentDetail>, IInventItemEnrolmentDetailRepository
    {
        public InventItemEnrolmentDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}