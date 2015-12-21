using Parakeet.Data;

namespace Parakeet.Services
{
    public interface IConfigurationService
    {
        /// <returns>True: success; False: failure;</returns>
        bool SetSavefilePath(string fullpathToSavefile, bool createIfFileDne);
    }

    public class ConfigurationService : IConfigurationService
    {
        private IDatabaseFileManager _databaseFileManager = DatabaseFileManager.Instance;
        public ConfigurationService()
        {
        }

        public bool SetSavefilePath(string fullpathToSavefile, bool createIfFileDne)
        {
            return _databaseFileManager.OpenFile(fullpathToSavefile, createIfFileDne);
        }
    }
}
