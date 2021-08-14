using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPImportInventTableHeaderRepository : IERPRepository<ERPImportInventTableHeader>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPImportInventTableHeaderRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public async Task<ERPImportInventTableHeader> AddAsync(ERPImportInventTableHeader entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = { entity.PurchId, entity.ImportInventTableType };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_ImportInventTableHeader", "Add", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

        public async Task<ERPImportInventTableHeader> ExecuteActionAsync(string action, object[] args)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_ImportInventTableHeader", action, args);
            ERPImportInventTableHeader entity = new ERPImportInventTableHeader();
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

            public IQueryable<ERPImportInventTableHeader> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableHeader> All(string searchString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableHeader> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ERPImportInventTableHeader GetById(long id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPImportInventTableHeader> UpdatAsync(ERPImportInventTableHeader entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableHeader> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

    }
}
