using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{

    public class ERPShipmentImportRepository : IERPRepository<ERPShipmentImport>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPShipmentImportRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public async Task<ERPShipmentImport> AddAsync(ERPShipmentImport entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.BLNumber, entity.Description, entity.Status };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_BLTable", "Add", args);
            entity.ERPRecId = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

        public IQueryable<ERPShipmentImport> All()
        {
            return _context.ERPShipmentImport.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPShipmentImport");
        }

        public IQueryable<ERPShipmentImport> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPShipmentImport.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPShipmentImport @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPShipmentImport> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPShipmentImport> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(long id)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { id };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_BLTable", "Delete", args);
            return result.CallAXClassMethodResult;
        }

        public Task<ERPShipmentImport> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPShipmentImport GetById(long id)
        {
            var recId = new SqlParameter("recId", id);
            return _context.ERPShipmentImport.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPShipmentImport @recId", recId).AsEnumerable().FirstOrDefault(x => x.ERPRecId == id);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<ERPShipmentImport> UpdatAsync(ERPShipmentImport entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.ERPRecId, entity.BLNumber, entity.Description, entity.Status };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_BLTable", "Update", args);
            entity.ERPRecId = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }
    }

}
