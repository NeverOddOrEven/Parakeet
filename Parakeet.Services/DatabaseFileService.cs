using Parakeet.Data.Migrator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Services
{
    public interface IDatabaseFileService
    {
        bool OpenFile(string openFromFullpath);
        bool CreateFile(string saveToFullpath);
    }

    public class DatabaseFileService : IDatabaseFileService
    {
        public bool OpenFile(string openFromFullpath)
        {
            return false;
        }

        public bool CreateFile(string saveToFullpath)
        {
            var fileExtension = Path.GetExtension(saveToFullpath);
            var dbName = Path.GetFileNameWithoutExtension(saveToFullpath);
            var directory = Path.GetDirectoryName(saveToFullpath);
            
            return GenerateDatabase.Create(directory, dbName, fileExtension, false);
        }
    }
}
