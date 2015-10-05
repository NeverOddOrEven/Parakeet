using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NHibernate;

namespace Parakeet.Data.Repositories
{
    public interface IRepository<T> 
    {
        int Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        T Update(T entity);
        T Where(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }

    
}
