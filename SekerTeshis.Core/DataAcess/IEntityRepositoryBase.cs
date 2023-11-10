using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Core.EntityFramework
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetByIdentity(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
