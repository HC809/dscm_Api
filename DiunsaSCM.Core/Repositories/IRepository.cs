using System;
using System.Linq;

namespace DiunsaSCM.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        IQueryable<TEntity> All();
        TEntity GetById(long id);
        TEntity Delete(TEntity entity);
        TEntity Update(TEntity entity);

        int SaveChanges();
    }
}
