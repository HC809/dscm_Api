using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}