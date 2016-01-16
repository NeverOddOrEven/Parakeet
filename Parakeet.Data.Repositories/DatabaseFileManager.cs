using Parakeet.Data.Migrator;
using System;
using System.IO;

namespace Parakeet.Data
{
    public interface IDatabaseFileManager
    {
        bool OpenFile(string openFromFullpath, bool createFileIfDne);
        bool HasConnectionString { get; }
        string ConnectionString { get; }
    }

    public class DatabaseFileManager : IDatabaseFileManager
    {
        private string _fullPathToDatabase;

        private static Lazy<IDatabaseFileManager> _databaseFileManager = null; // Lazy adds threadsafety for free; lazy is good!
        public static IDatabaseFileManager Instance { get
            {
                return _databaseFileManager.Value;
            }
            private set
            {
                if (_databaseFileManager != null)
                    throw new InvalidOperationException("The database file manager is already set. Opening a new one could cause data corruption.");
                _databaseFileManager = new Lazy<IDatabaseFileManager>(() => value);
            }
        }
        
        public DatabaseFileManager() {
            Instance = this;
        }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_fullPathToDatabase))
                    throw new ApplicationException("No file is open...");

                var dbName = Path.GetFileNameWithoutExtension(_fullPathToDatabase);
                return GenerateDatabase.GetConnectionString(_fullPathToDatabase, dbName);
            }
        }

        public bool HasConnectionString
        {
            get
            {
                return !string.IsNullOrEmpty(_fullPathToDatabase);
            }
        }

        public bool OpenFile(string openFileFullpath, bool createFileIfDne)
        {
            if (string.IsNullOrEmpty(openFileFullpath))
                return false;

            var fileExists = File.Exists(openFileFullpath);

            if (fileExists)
            {
                _fullPathToDatabase = openFileFullpath;
            } else
            {
                if (CreateFile(openFileFullpath))
                {
                    _fullPathToDatabase = openFileFullpath;
                    return true;
                }
                return false;
            }

            return fileExists;
        }

        private bool CreateFile(string saveToFullpath)
        {
            var fileExtension = Path.GetExtension(saveToFullpath);
            var dbName = Path.GetFileNameWithoutExtension(saveToFullpath);
            var directory = Path.GetDirectoryName(saveToFullpath);
            
            return GenerateDatabase.Create(directory, dbName, fileExtension, false) && File.Exists(saveToFullpath);
        }
    }
}
