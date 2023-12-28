using HrApp.Domain.Common;
using HrApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.Repositories.Generic
{
   public abstract class GenericRepository<T> : IRepository<T> where T : class, IEntity
   {
      private readonly HrAppDbContext _context;
      private readonly DbSet<T> _dbSet;

      public GenericRepository(HrAppDbContext context)
      {
         _context = context;
         _dbSet = _context.Set<T>();
      }

      public async Task AddAsync(T entity)
      {
         await _dbSet.AddAsync(entity);
      }

      public async Task DeleteAsync(T entity)
      {
         await Task.Run(() => _dbSet.Remove(entity));
      }

      public async Task UpdateAsync(T entity)
      {
         await Task.Run(() => _dbSet.Update(entity));
      }

      public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
      {
         IQueryable<T> query = _dbSet;

         if (filter != null)
         {
            query = query.Where(filter);
         }

         if (includeProperties.Any())
         {
            foreach (var item in includeProperties)
            {
               query = query.Include(item);
            }

         }

         if (asNoTracking)
         {
            query = query.AsNoTracking();
         }

         var result = await query.ToListAsync();

         return result;
      }

      public async Task<T> GetAsync(bool asNoTracking = true, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
      {
         IQueryable<T> query = _dbSet;

         if (filter != null)
         {
            query = query.Where(filter);
         }

         if (includeProperties.Any())
         {
            foreach (var item in includeProperties)
            {
               query = query.Include(item);
            }

         }

         if (asNoTracking)
         {
            query = query.AsNoTracking();
         }

         var result = await query.SingleAsync();

         return result;
      }
   }
}
