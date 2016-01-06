using System;
using System.Linq;
using System.Linq.Expressions;
using Parakeet.Data.Repositories;
using System.Collections.Generic;
using Parakeet.Data.Entities;

namespace Parakeet.Ui.Design
{
    /// <summary>
    /// Basically an in-memory data store repository for driving the designer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        private Dictionary<long, T> Data;

        public Repository() {
            Data = new Dictionary<long, T>();
        }

        public T Add(T entity)
        {
            long id = Data.Count;
            entity.Id = id;
            Data.Add(id, entity);

            return entity;
        }

        public void Delete(long id)
        {
            Data.Remove(id);
        }

        public void Delete(T entity)
        {
            Data.Remove(entity.Id.Value);
        }

        public T Update(T entity)
        {
            Data[entity.Id.Value] = entity;

            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Data.Values.AsQueryable().Where(predicate);
        }

        public T Where(long id)
        {
            T entity;
            Data.TryGetValue(id, out entity);

            return entity;
        }
    }
}
