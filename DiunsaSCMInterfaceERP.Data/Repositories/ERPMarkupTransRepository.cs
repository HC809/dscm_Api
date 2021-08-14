using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPMarkupTransRepository : IERPRepository<ERPMarkupTrans>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPMarkupTransRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public Task<ERPMarkupTrans> AddAsync(ERPMarkupTrans entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPMarkupTrans> All()
        {
            return _context.ERPMarkupTrans.FromSqlRaw($"EXECUTE dbo.SP_SCM_GetERPMarkupTransByShipmentImport");
        }

        public IQueryable<ERPMarkupTrans> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPMarkupTrans.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPMarkupTransByShipmentImport @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPMarkupTrans> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPMarkupTrans> AllByParent(long parent)
        {
            return _context.ERPMarkupTrans.FromSqlRaw($"EXECUTE dbo.SP_SCM_GetERPMarkupTransByShipmentImport @shipmentImportRecId = {parent}");
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPMarkupTrans> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPMarkupTrans GetById(long id)
        {
            var recId = new SqlParameter("recId", id);
            return _context.ERPMarkupTrans.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPMarkupTransByShipmentImport @recId", recId).AsEnumerable().FirstOrDefault(x => x.ERPRecId == id);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPMarkupTrans> UpdatAsync(ERPMarkupTrans entity)
        {
            throw new NotImplementedException();
        }
    }
}
