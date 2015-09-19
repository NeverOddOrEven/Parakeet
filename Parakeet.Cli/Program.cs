using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parakeet.Data.Migrator;

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

            
        }
    }
}
