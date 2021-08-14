using System;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data
{
    public class SalesPriceDefinitionRepository : RepositoryBase<SalesPriceDefinition>, ISalesPriceDefinitionRepository
    {
        public SalesPriceDefinitionRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        protected override IQueryable<SalesPriceDefinition> GetAllCustom(IQueryable<SalesPriceDefinition> query, string searchString = "", int slice = 0)
        {
            query = query
                .Where(x => String.IsNullOrEmpty(searchString)
                || x.Code.Contains(searchString)
                || x.Description.Contains(searchString)
                || x.Reference.Contains(searchString)
                ).OrderByDescending(x => x.Id);
            if (slice > 0)
            {
                query = query.Take(slice);
            }
            return query;
        }
    }
}