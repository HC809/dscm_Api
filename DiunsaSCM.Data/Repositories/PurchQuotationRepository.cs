using System;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class PurchQuotationRepository : RepositoryBase<PurchQuotation>, IPurchQuotationRepository
    {
        public PurchQuotationRepository(DiunsaSCMContext context)
            : base(context)
        {
        }

        protected override IQueryable<PurchQuotation> GetAllCustom(IQueryable<PurchQuotation> query, string searchString = "", int slice = 0)
        {
            query = query
                .Include(x => x.Vendor)
                .Include(x => x.Currency)
                .Include(x => x.PurchPaymentCondition)
                .Include(x => x.Warehouse)
                .Include(x => x.PurchCommercialDepartment)
                .Include(x => x.PurchQuotationApprovalRuleCondition)
                .Include(x => x.PurchQuotationApprovalRuleConditionStep)
                .ThenInclude(x => x.PurchRole)
                .Where(x => String.IsNullOrEmpty(searchString)
                || x.Code.Contains(searchString)
                || x.Description.Contains(searchString)
                || (x.Vendor != null && x.Vendor.Code.Contains(searchString))
                || (x.Vendor != null && x.Vendor.Description.Contains(searchString))
                ).OrderByDescending(x => x.Id);
            if (slice > 0)
            {
                query = query.Take(slice);
            }
            return query;
        }

        public PurchQuotation GetById(long id)
        {
            return _context.PurchQuotation.Include(x=> x.Vendor).FirstOrDefault(x=> x.Id == id);
        }
    }
}