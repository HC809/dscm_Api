using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class ItemHierarchyRepository : RepositoryBase<ItemHierarchy>, IItemHierarchyRepository
    {
        public ItemHierarchyRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}