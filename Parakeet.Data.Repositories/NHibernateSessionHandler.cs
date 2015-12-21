using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Parakeet.Data.Mappings;

namespace Parakeet.Data
{
    public static class NHibernateSessionHandler
    {
        private static bool IsSetForUnitTest = false;

        public static ISessionFactory SessionFactory { get { return _sessionFactory.Value; } }
        private static Lazy<ISessionFactory> _sessionFactory = new Lazy<ISessionFactory>(() =>
        {
            var connString = IsSetForUnitTest
                ? "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\asuttmiller\\documents\\visual studio 2013\\Projects\\Parakeet\\Parakeet.Data\\UnitTest.mdf\";Integrated Security=True"
                : DatabaseFileManager.Instance.ConnectionString;

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connString))
                .Mappings(m => m.FluentMappings.Add<PersonMap>())
                .Mappings(m => m.FluentMappings.Add<RoleMap>())
                .BuildSessionFactory();

            return sessionFactory;
        });

        public static void InitForUnitTest()
        {
            IsSetForUnitTest = false;
        }
    }
}
