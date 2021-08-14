using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiunsaSCM.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DiunsaSCMContext _context;

        protected virtual IEnumerable<Expression<Func<TEntity, object>>> getAllAsyncIncludes()
        {
            List<Expression<Func<TEntity, object>>> includeExpressions = new List<Expression<Func<TEntity, object>>>();
            return includeExpressions;
        }

        protected virtual IQueryable<TEntity> GetAllCustom(IQueryable<TEntity> query, string searchString = "", int slice = 0)
        {
            return query;
        }

        public RepositoryBase(DiunsaSCMContext context)
        {
            this._context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<IQueryable<TEntity>> AllAsync()
        {
            var includeExpressions = this.getAllAsyncIncludes();
            var result = await includeExpressions
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_context.Set<TEntity>(), (current, expression) => current.Include(expression))
                .ToListAsync(); ;
            return result.AsQueryable();
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

        public IQueryable<TEntity> All(string searchString = "", int slice = 0)
        {
            var includeExpressions = this.getAllAsyncIncludes();
            var result = includeExpressions
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_context.Set<TEntity>(), (current, expression) => current.Include(expression));

            result = this.GetAllCustom(result,searchString, slice);
            return result;
        }
    }
}
