using Parakeet.Data.Migrator;
using System;
using System.IO;

namespace Parakeet.Data
{
    public interface IDatabaseFileManager
    {
        bool OpenFile(string openFromFullpath, bool createFileIfDne);
        string ConnectionString { get; }
    }

    public class DatabaseFileManager : IDatabaseFileManager
    {
        private string _fullPathToDatabase;

        private static Lazy<IDatabaseFileManager> _databaseFileManager = null; // Lazy adds threadsafety for free; lazy is good!
        public static IDatabaseFileManager Instance { get
            {
                if (_databaseFileManager == null)
                    _databaseFileManager = new Lazy<IDatabaseFileManager>(() => new DatabaseFileManager());
                return _databaseFileManager.Value;
            }
            set
            {
                _databaseFileManager = new Lazy<IDatabaseFileManager>(() => value);
            }
        }

        // Do not allow outside instantiations.
        private DatabaseFileManager() { }

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
                return CreateFile(openFileFullpath);
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
