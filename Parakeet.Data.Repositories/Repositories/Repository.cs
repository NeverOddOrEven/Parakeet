using System.Linq.Expressions;
using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Parakeet.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private ISessionFactory _sessionFactory;

        public Repository() : this(NHibernateSessionHandler.SessionFactory) { } 

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public T Add(T entity)
        {
            using (var session = BeginSession())
            {
                using (var transaction = session.Transaction)
                {
                    transaction.Begin();
                    session.Save(entity);
                    transaction.Commit();
                    return entity;
                }
            }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            using (var session = BeginSession())
            {
                using (var transaction = session.Transaction)
                {
                    transaction.Begin();
                    session.Update(entity);
                    transaction.Commit();

                    return entity;
                }
            }
        }

        public T Where(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> results;

            using (var session = BeginSession())
            {
                results = session.Query<T>().Where(predicate).ToList().AsQueryable();
            }

            return results;
        }

        protected ISession BeginSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
