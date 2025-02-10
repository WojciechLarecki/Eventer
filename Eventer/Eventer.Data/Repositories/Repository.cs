using Eventer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EventerContext _context;
        protected Repository(EventerContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll(bool trackChanges = false, Expression<Func<T, bool>>? condition = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!trackChanges)
                query = query.AsNoTracking();
            if (condition != null)
                query = query.Where(condition);

            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, Expression<Func<T, bool>>? condition = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!trackChanges)
                query = query.AsNoTracking();
            if (condition != null)
                query = query.Where(condition);

            return await query.ToListAsync();
        }

        public T? GetOne(bool trackChanges = false, Expression<Func<T, bool>>? condition = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!trackChanges)
                query = query.AsNoTracking();
            if (condition != null)
                query = query.Where(condition);

            return query.FirstOrDefault();
        }

        public Task<T?> GetOneAsync(bool trackChanges = false, Expression<Func<T, bool>>? condition = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!trackChanges)
                query = query.AsNoTracking();
            if (condition != null)
                query = query.Where(condition);

            return query.FirstOrDefaultAsync();
        }
    }
}
