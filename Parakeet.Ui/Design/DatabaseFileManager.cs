using System;
using Parakeet.Data;

namespace Parakeet.Ui.Design
{
    class DatabaseFileManager : IDatabaseFileManager
    {
        public string ConnectionString
        {
            get
            {
                throw new InvalidOperationException("Designer should not be trying to connect to any files");
            }
        }

        public bool HasConnectionString
        {
            get
            {
                return true;
            }
        }

        public bool OpenFile(string openFromFullpath, bool createFileIfDne)
        {
            return true;
        }
    }
}
