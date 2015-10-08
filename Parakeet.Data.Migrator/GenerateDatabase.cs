using System;
using System.IO;
using System.Data.SqlClient;

namespace Parakeet.Data.Migrator
{
    public static class GenerateDatabase
    {
        public static void Create(string absolutePath, string dbName, bool recreateIfExists = false)
        {
            if (!Directory.Exists(absolutePath))
                Directory.CreateDirectory(absolutePath);

            string dbFileName = Path.GetFileNameWithoutExtension(dbName);

            if (recreateIfExists && File.Exists(Path.Combine(absolutePath, dbFileName + ".mdf")))
            {
                File.Delete(Path.Combine(absolutePath, dbFileName + ".mdf"));
                File.Delete(Path.Combine(absolutePath, dbFileName + "_log.ldf"));
            }

            if (!File.Exists(Path.Combine(absolutePath, dbFileName + ".mdf")))
                CreateDatabase(Path.Combine(absolutePath, dbFileName + ".mdf"), dbName);
        }

        private static void CreateDatabase(string fullPath, string dbName)
        {
            string connectionString = String.Format(@"Data Source=(LocalDB)\v11.0;Initial Catalog=master;Integrated Security=True");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                DetachDatabase(dbName);

                cmd.CommandText = String.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, fullPath);
                cmd.ExecuteNonQuery();
            }
        }

        private static void DetachDatabase(string dbName) {
            string connectionString = @"Data Source=(LocalDB)\v11.0;Initial Catalog=master;Integrated Security=True";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = String.Format("exec sp_detach_db '{0}'", dbName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("Database: {0}, was not in the catalog. No need to detach the database.", dbName);
            }
        }
    }
}
