using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Parakeet.Data.Entities;

namespace Parakeet.Data
{
    public class Configuration
    {
        private static ISessionFactory SessionFactory { get; set; }

        static Configuration()
        {
            
        }
    }
}
