using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class InventItemRepository : RepositoryBase<InventItem>, IInventItemRepository
    {
        public InventItemRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        protected override IQueryable<InventItem> GetAllCustom(IQueryable<InventItem> query, string searchString = "", int slice = 0)
        {
            query = query
                .Include(x => x.Vendor)
                .Where(x => String.IsNullOrEmpty(searchString)
                || x.Code.Contains(searchString)
                || x.Description.Contains(searchString)
                || x.NameAlias.Contains(searchString)
                || (x.Vendor != null && x.Vendor.Code.Contains(searchString))
                || (x.Vendor != null && x.Vendor.Description.Contains(searchString))
                );
            if (slice > 0)
            { 
                query = query.Take(slice);
            }
            return query;
        }



    }
}
