using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parakeet.Services
{
    public interface IDatabaseFileService
    {
        bool OpenFile(string openFromFullpath);
        bool SaveFile(string saveToFullpath);
    }

    public class DatabaseFileService : IDatabaseFileService
    {
        public bool OpenFile(string openFromFullpath)
        {
            return false;
        }

        public bool SaveFile(string saveToFullpath)
        {
            return false;
        }
    }
}
