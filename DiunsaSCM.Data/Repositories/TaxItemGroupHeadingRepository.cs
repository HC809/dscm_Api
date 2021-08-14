
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class TaxItemGroupHeadingRepository : RepositoryBase<TaxItemGroupHeading>, ITaxItemGroupHeadingRepository
    {
        public TaxItemGroupHeadingRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}