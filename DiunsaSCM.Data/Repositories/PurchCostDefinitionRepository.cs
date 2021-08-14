using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchCostDefinitionRepository : RepositoryBase<PurchCostDefinition>, IPurchCostDefinitionRepository
    {
        public PurchCostDefinitionRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}