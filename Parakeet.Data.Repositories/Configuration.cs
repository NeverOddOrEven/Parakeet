using NHibernate;

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
