using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Parakeet.Data.Entities;

namespace Parakeet.Data
{
    public static class NHibernateSessionHandler
    {
        private static ISessionFactory _sessionFactory {get; set;}

        static NHibernateSessionHandler()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>
                    c.Server("localhost").Database("parakeet.mdf")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
                .BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory { get { return _sessionFactory; } }
    }
}
