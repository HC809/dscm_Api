using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiunsaSCM.Core.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        TEntity Add(TEntity entity);
        Task<IQueryable<TEntity>> AllAsync();
        IQueryable<TEntity> All(string searchString = "", int slice = 0);
        TEntity GetById(long id);
        TEntity Delete(TEntity entity);
        TEntity Update(TEntity entity);

        int SaveChanges();
    }
}
