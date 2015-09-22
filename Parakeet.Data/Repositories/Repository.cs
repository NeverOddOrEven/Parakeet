using System.Linq.Expressions;
using System;
using System.Linq;
using NHibernate;

namespace Parakeet.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private ISessionFactory sessionFactory;

        public Repository() : this(NHibernateSessionHandler)

        public Repository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Where(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
