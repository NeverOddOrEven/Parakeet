using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parakeet.Data.Migrator;
using Parakeet.Data.Repositories;
using Parakeet.Data.Entities;

namespace Parakeet.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Migrating the database up...");
            var connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\asuttmiller\\documents\\visual studio 2013\\Projects\\Parakeet\\Parakeet.Data\\Parakeet.mdf\";Integrated Security=True";
            Runner.MigrateToLatest(connectionString);
            Console.WriteLine("Done migrating up...");
            Console.ReadLine();

            var repositoryCache = new RepositoryCache();

            var peopleRepository = repositoryCache.PeopleRepository;

            try
            {
                peopleRepository.Add(new Person { FirstName = "Alex", LastName = "Suttmiller", Id = 10 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
