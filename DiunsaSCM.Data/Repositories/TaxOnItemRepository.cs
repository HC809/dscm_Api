using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class TaxOnItemRepository : RepositoryBase<TaxOnItem>, ITaxOnItemRepository
    {
        public TaxOnItemRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}