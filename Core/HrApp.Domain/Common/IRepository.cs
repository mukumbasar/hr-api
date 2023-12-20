using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Common
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
