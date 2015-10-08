using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Data.Migrator
{
    class Program
    {
        static void Main(string [] args)
        {
            if (args.Length == 0)
                args = new string[] {"up"};

            var dbPath = @"C:\Users\asuttmiller\documents\visual studio 2013\Projects\Parakeet\Parakeet.Data";
            var dbName = "Parakeet";
            bool up = true;            
            
            if (args[0] == "unittest:down")
            {
                dbName = "Unittest";
                up = false;
            }
            else if (args[0] == "down")
            {
                up = false;
            }
            else if (args[0] == "unittest:up") 
            {
                dbName = "Unittest";
            }
            
            var connStr = String.Format("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"{0}\\{1}.mdf\";Integrated Security=True", dbPath, dbName);
            
            Console.WriteLine("Applying migrations...");
            if (up == true)
            {
                GenerateDatabase.Create(dbPath, dbName, false);
                Runner.MigrateToLatest(connStr);
            }
            else
            {
                GenerateDatabase.Create(dbPath, dbName, false);
                Runner.MigrateDownOne(connStr);
            }

            Console.WriteLine("Done applying migrations...");
            
            return;
        }
    }
}
