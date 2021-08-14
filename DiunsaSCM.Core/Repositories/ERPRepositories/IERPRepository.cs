using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;

namespace DiunsaSCM.Core.Repositories.ERPRepositories
{
    public interface IERPRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        IQueryable<TEntity> All();
        IQueryable<TEntity> All(string searchString);
        IEnumerable<TEntity> AllByFilterModel(FilterBaseDTO filterModel);
        IQueryable<TEntity> AllByParent(long parent);
        TEntity GetById(long id);
        Task<TEntity> UpdatAsync(TEntity entity);
        Task<string> DeleteAsync(long id);
        int SaveChanges();
        Task<TEntity> ExecuteActionAsync(string action, object[] args);
    }
}
