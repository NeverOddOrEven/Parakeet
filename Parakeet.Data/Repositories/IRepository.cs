using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Parakeet.Data.Repositories
{
    public interface IRepository<T> 
    {
        int Add<T>(T entity);
        void Delete<T>(T entity);
        void Delete<T>(int id);
        T Update<T>(T entity);
        T Where(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }

    
}
