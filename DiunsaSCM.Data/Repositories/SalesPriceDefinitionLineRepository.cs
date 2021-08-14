using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data
{
    public class SalesPriceDefinitionLineRepository : RepositoryBase<SalesPriceDefinitionLine>, ISalesPriceDefinitionLineRepository
    {
        public SalesPriceDefinitionLineRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        protected override IQueryable<SalesPriceDefinitionLine> GetAllCustom(IQueryable<SalesPriceDefinitionLine> query, string searchString = "", int slice = 0)
        {
            query = query.Include(x => x.InventItem);
            if (slice > 0)
            {
                query = query.Take(slice);
            }
            return query;
        }
    }
}