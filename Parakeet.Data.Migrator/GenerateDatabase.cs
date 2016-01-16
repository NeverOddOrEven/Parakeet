using System;
using System.IO;
using System.Data.SqlClient;

namespace Parakeet.Data.Migrator
{
    public static class GenerateDatabase
    {
        public static string GetConnectionString(string fullpath, string dbName)
        {
            var connectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{0}\";Initial Catalog={1};Integrated Security=True", fullpath, dbName);
            return connectionString;
        }

        public static bool Create(string directory, string dbName, string extension, bool recreateIfExists = false)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string fullpath = Path.Combine(directory, Path.ChangeExtension(dbName, extension));
            string dbLogPath = Path.Combine(directory, Path.ChangeExtension(dbName + "_log", ".ldf"));
            string dbFileName = Path.GetFileNameWithoutExtension(dbName);

            if (recreateIfExists && File.Exists(fullpath))
            {
                File.Delete(fullpath);
                File.Delete(dbLogPath);
            }

            if (!File.Exists(fullpath))
            {
                if (CreateDatabase(directory, dbName, extension))
                {
                    try
                    {
                        var connectionString = GetConnectionString(fullpath, dbName);
                        Runner.MigrateToLatest(connectionString);

                        System.GC.Collect();

                        DetachDatabase(dbName);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }

            }
            
            return false;
        }

        private static bool CreateDatabase(string directory, string dbName, string extension)
        {
            string fullpath = Path.Combine(directory, Path.ChangeExtension(dbName, extension));

            try {
                string connectionString = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True");

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = string.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, fullpath);
                    cmd.ExecuteNonQuery();
                }

                DetachDatabase(dbName);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void DetachDatabase(string dbName) {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    var cmdTxt = string.Format(@"
                        USE [master];
                        
                        ALTER DATABASE [{0}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        
                        USE [master];
                        
                        exec sp_detach_db '{0}';
                        ", dbName);
                    cmd.CommandText = cmdTxt;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: {0}, was not in the catalog. No need to detach the database.", dbName);
            }
        }
    }
}
