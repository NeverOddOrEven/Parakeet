using System;
using System.Linq;
using System.Linq.Expressions;

namespace Parakeet.Data.Repositories
{
    public interface IRepository<T> 
    {
        T Add(T entity);
        void Delete(T entity);
        void Delete(long id);
        T Update(T entity);
        T Where(long id);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
