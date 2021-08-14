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

namespace DiunsaSCMInterfaceERP.Data.Repositories
{

    public class ERPVendorRepository : IERPRepository<ERPVendor>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPVendorRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public Task<ERPVendor> AddAsync(ERPVendor entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPVendor> All()
        {
            return _context.ERPVendor.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPVendor");
        }

        public IQueryable<ERPVendor> All(string searchString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPVendor> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPVendor> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPVendor> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPVendor GetById(long id)
        {
            return _context.ERPVendor.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPVendor @recId", id).FirstOrDefault(x => x.Id == id); ;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPVendor> UpdatAsync(ERPVendor entity)
        {
            throw new NotImplementedException();
        }
    }
}
