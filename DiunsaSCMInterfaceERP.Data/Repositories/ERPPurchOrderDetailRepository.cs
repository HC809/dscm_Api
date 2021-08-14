using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPPurchOrderDetailRepository : IERPRepository<ERPPurchOrderDetail>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPPurchOrderDetailRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public async Task<ERPPurchOrderDetail> AddAsync(ERPPurchOrderDetail entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.Id, entity.ItemId };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchLine", "Add", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

        public IQueryable<ERPPurchOrderDetail> All()
        {
            return _context.ERPPurchOrderDetail.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPPurchOrderDetail");
        }

        public IQueryable<ERPPurchOrderDetail> All(string searchString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPPurchOrderDetail> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPPurchOrderDetail> AllByParent(long purchOrderHeaderId)
        {
            return _context.ERPPurchOrderDetail.FromSqlRaw($"EXECUTE dbo.SP_SCM_GetERPPurchOrderDetail @purchOrderRecId = {purchOrderHeaderId}");
        }

        public async Task<string> DeleteAsync(long id)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { id };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchLine", "Delete", args);
            return result.CallAXClassMethodResult;
        }

        public Task<ERPPurchOrderDetail> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPPurchOrderDetail GetById(long id)
        {
            return _context.ERPPurchOrderDetail.FromSqlRaw($"EXECUTE dbo.SP_SCM_GetERPPurchOrderDetail @RecId = {id}").FirstOrDefault();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<ERPPurchOrderDetail> UpdatAsync(ERPPurchOrderDetail entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.Id, entity.ItemId };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_PurchLine", "Update", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }
    }
}
