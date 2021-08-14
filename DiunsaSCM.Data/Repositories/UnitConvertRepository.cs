using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class UnitConvertRepository : RepositoryBase<UnitConvert>, IUnitConvertRepository
    {
        public UnitConvertRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
