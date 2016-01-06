using System;
using Parakeet.Services;

namespace Parakeet.Ui.Design
{
    public class ConfigurationService : IConfigurationService
    {
        public bool IsFileLoaded()
        {
            return true;
        }

        public bool SetSavefilePath(string fullpathToSavefile, bool createIfFileDne)
        {
            return true;
        }
    }
}
