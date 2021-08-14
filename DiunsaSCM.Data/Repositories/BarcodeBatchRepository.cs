using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class BarcodeBatchRepository : RepositoryBase<BarcodeBatch>, IBarcodeBatchRepository
    {
        public BarcodeBatchRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}