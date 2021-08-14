using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemGroupRepository : RepositoryBase<InventItemGroup>, IInventItemGroupRepository
    {
        public InventItemGroupRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}