using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class ItemSeasonalCategoryRepository : RepositoryBase<ItemSeasonalCategory>, IItemSeasonalCategoryRepository
    {
        public ItemSeasonalCategoryRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}