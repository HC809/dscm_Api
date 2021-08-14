using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories.ERPRepositories;
using DiunsaSCMInterfaceERP.Core.Entities.ERPEntities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories.ERPRespositories
{
    public class ERPReceiptDetailRepository : IERPRepository<ERPReceiptDetail>
    {
        private readonly DiunsaSCMERPContext _context;

        public ERPReceiptDetailRepository(DiunsaSCMERPContext context)
        {
            _context = context;
        }

        public ERPReceiptDetailRepository()
        {
        }

        public Task<ERPReceiptDetail> AddAsync(ERPReceiptDetail entity)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<ERPReceiptDetail> All()
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<ERPReceiptDetail> All(string searchString)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ERPReceiptDetail> AllByFilterModel(FilterBaseDTO filterModel)
        {
            FilterPurchShipmentDTO filter = (FilterPurchShipmentDTO)filterModel;

            object[] parameters = {
                new SqlParameter("purchId", filter.PurchId),
                new SqlParameter("purchOrderShipmetId", filter.PurchOrderShipmentHeaderId),
            };

            return _context.ERPReceiptDetail.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPReceiptDetail @purchId=@purchId, @purchOrderShipmetId=@purchOrderShipmetId", parameters)
                .AsEnumerable<ERPReceiptDetail>();
        }

        public System.Linq.IQueryable<ERPReceiptDetail> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPReceiptDetail> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPReceiptDetail GetById(long id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPReceiptDetail> UpdatAsync(ERPReceiptDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
