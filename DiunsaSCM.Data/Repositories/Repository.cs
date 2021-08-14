using System;
using System.Linq;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DiunsaSCMContext _context;

        public Repository(DiunsaSCMContext context)
        {
            this._context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public IQueryable<TEntity> All()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Filter()
        {
            return _context.Set<TEntity>();
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
