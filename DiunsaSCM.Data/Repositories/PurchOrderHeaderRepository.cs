using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Entities;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchOrderHeaderRepository : RepositoryBase<PurchOrderHeader>, IPurchOrderHeaderRepository
    {
        public PurchOrderHeaderRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        protected override IQueryable<PurchOrderHeader> GetAllCustom(IQueryable<PurchOrderHeader> query, string searchString = "", int slice = 0)
        {
            query = query
                .Where(x => String.IsNullOrEmpty(searchString)
                || x.Code.Contains(searchString)
                || x.PurchName.Contains(searchString)
                || x.Reference.Contains(searchString)
                || x.VendorAccount.Contains(searchString)
                ).OrderByDescending(x => x.Id);

            if (slice > 0)
            {
                query = query.Take(slice);
            }
            return query;
        }
    }
}
