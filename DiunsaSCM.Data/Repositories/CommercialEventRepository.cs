using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
namespace DiunsaSCM.Data
{
    public class CommercialEventRepository : RepositoryBase<CommercialEvent>, ICommercialEventRepository
    {
        public CommercialEventRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}