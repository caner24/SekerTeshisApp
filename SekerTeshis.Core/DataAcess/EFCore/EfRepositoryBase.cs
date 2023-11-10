using Microsoft.EntityFrameworkCore;
using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Core.DataAcess.EFCore
{
    public class EfRepositoryBase<TContext, TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity,
        new()
        where TContext : DbContext, new()
    {
        private readonly TContext _tContext;
        public EfRepositoryBase(TContext context)
        {
            _tContext = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _tContext.AddAsync(entity);
            await _tContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetByIdentity(Expression<Func<TEntity, bool>> filter)
        {
            return _tContext.Set<TEntity>().Where(filter);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
