using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemStoreConfigurationRepository : RepositoryBase<InventItemStoreConfiguration>, IInventItemStoreConfigurationRepository
    {
        public InventItemStoreConfigurationRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}