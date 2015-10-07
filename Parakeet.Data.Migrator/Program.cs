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

            var unitTestDb = "";
            var mainDb = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\asuttmiller\\documents\\visual studio 2013\\Projects\\Parakeet\\Parakeet.Data\\Parakeet.mdf\";Integrated Security=True";

            string conn;
            bool up = true;
            if (args[0] == "unittest:down")
            {
                conn = unitTestDb;
                up = false;
            }
            else if (args[0] == "down")
            {
                conn = mainDb;
                up = false;
            }
            else if (args[0] == "unittest:down")
                conn = unitTestDb;
            else
                conn = mainDb;

            Console.WriteLine("Applying migrations...");
            if (up == true)
            {
                Runner.MigrateToLatest(conn);
            }
            else
            {
                Runner.MigrateDownOne(conn);
            }

            Console.WriteLine("Done applying migrations...");
            
            return;
        }
    }
}
