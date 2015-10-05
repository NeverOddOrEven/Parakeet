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
        private static ISessionFactory _sessionFactory {get; set;}

        static NHibernateSessionHandler()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(
                        "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\asuttmiller\\documents\\visual studio 2013\\Projects\\Parakeet\\Parakeet.Data\\Parakeet.mdf\";Integrated Security=True"))
                    
                .Mappings(m => m.FluentMappings.Add<PersonMap>())
                .BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory { get { return _sessionFactory; } }
    }
}
