using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventDimGroupRepository : RepositoryBase<InventDimGroup>, IInventDimGroupRepository
    {
        public InventDimGroupRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
