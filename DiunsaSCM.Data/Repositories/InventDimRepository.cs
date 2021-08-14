using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventDimRepository : RepositoryBase<InventDim>, IInventDimRepository
    {
        public InventDimRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}