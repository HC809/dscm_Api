using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPPurchOrderHeaderRespository : IERPRepository<ERPPurchOrderHeader>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPPurchOrderHeaderRespository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public async Task<ERPPurchOrderHeader> AddAsync(ERPPurchOrderHeader entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.PurchName, entity.VendorAccount };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchTable", "Add", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

        public IQueryable<ERPPurchOrderHeader> All()
        {
            return _context.ERPPurchOrderHeader.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPPurchOrderHeader");
        }

        public IQueryable<ERPPurchOrderHeader> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPPurchOrderHeader.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPPurchOrderHeader @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPPurchOrderHeader> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPPurchOrderHeader> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(long id)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { id };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchTable", "Delete", args);
            return result.CallAXClassMethodResult;
        }

        public Task<ERPPurchOrderHeader> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPPurchOrderHeader GetById(long id)
        {
            var recId = new SqlParameter("recId", id);
            return _context.ERPPurchOrderHeader.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPPurchOrderHeader @recId", recId).AsEnumerable().FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<ERPPurchOrderHeader> UpdatAsync(ERPPurchOrderHeader entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.Id, entity.PurchName};
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchTable", "Update", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }
    }
}
