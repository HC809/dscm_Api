using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchCostDefinitionLineRepository : RepositoryBase<PurchCostDefinitionLine>, IPurchCostDefinitionLineRepository
    {
        public PurchCostDefinitionLineRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}