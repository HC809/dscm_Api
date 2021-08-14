using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPItemBarcodeRepository : IERPRepository<ERPItemBarcode>
    {

        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPItemBarcodeRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public Task<ERPItemBarcode> AddAsync(ERPItemBarcode entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPItemBarcode> All()
        {
            return _context.ERPItemBarcode.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPItemBarcode");
        }

        public IQueryable<ERPItemBarcode> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPItemBarcode.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPItemBarcode @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPItemBarcode> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPItemBarcode> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPItemBarcode> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPItemBarcode GetById(long id)
        {
            return _context.ERPItemBarcode.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPItemBarcode @recId", id).FirstOrDefault(x => x.Id == id); ;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPItemBarcode> UpdatAsync(ERPItemBarcode entity)
        {
            throw new NotImplementedException();
        }
    }
}
