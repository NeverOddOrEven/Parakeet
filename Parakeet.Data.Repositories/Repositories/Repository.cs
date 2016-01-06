﻿using System.Linq.Expressions;
using System;
using System.Linq;
using NHibernate;

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
            throw new NotImplementedException();
        }

        public T Where(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        protected ISession BeginSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
