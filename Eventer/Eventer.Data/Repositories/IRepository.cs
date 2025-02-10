using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool trackChanges = false, Expression<Func<T, bool>>? condition = null);
        T? GetOne(bool trackChanges = false, Expression<Func<T, bool>>? condition = null);
        Task<T?> GetOneAsync(bool trackChanges = false, Expression<Func<T, bool>>? condition = null);
    }
}
