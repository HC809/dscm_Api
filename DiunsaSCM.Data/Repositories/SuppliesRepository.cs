using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class SuppliesRepository : RepositoryBase<Supplies>, ISuppliesRepository
    {
        public SuppliesRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
