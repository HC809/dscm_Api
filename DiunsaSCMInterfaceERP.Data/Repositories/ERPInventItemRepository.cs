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
    public class ERPInventItemRepository : IERPRepository<ERPInventItem>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPInventItemRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public Task<ERPInventItem> AddAsync(ERPInventItem entity)
        {
            throw new NotImplementedException();
        }


        public IQueryable<ERPInventItem> All()
        {
            return _context.ERPInventItem.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPInventItem");
        }

        public IQueryable<ERPInventItem> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPInventItem.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPInventItem @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPInventItem> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPInventItem> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPInventItem> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPInventItem GetById(long id)
        {
            return _context.ERPInventItem.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPInventItem @recId", id).FirstOrDefault(x => x.Id == id); ;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPInventItem> UpdatAsync(ERPInventItem entity)
        {
            throw new NotImplementedException();
        }

    }
}
