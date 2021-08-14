using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventModelGroupRepository : RepositoryBase<InventModelGroup>, IInventModelGroupRepository
    {
        public InventModelGroupRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}