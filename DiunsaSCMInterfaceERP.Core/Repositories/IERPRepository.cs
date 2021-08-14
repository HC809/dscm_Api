using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Models;

namespace DiunsaSCMInterfaceERP.Core.Repositories
{
    public interface IERPRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        IQueryable<TEntity> All();
        IQueryable<TEntity> All(string searchString);
        IQueryable<TEntity> AllByFilterModel(ERPFilterBaseDTO filterModel);
        IQueryable<TEntity> AllByParent(long parent);
        TEntity GetById(long id);
        Task<TEntity>UpdatAsync(TEntity entity);
        Task<string> DeleteAsync(long id);
        int SaveChanges();
        Task<TEntity> ExecuteActionAsync(string action, object[] args);
    }
}
