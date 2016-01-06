using Parakeet.Data;

namespace Parakeet.Services
{
    public interface IConfigurationService
    {
        /// <returns>True: success; False: failure;</returns>
        bool SetSavefilePath(string fullpathToSavefile, bool createIfFileDne);
        bool IsFileLoaded();
    }

    public class ConfigurationService : IConfigurationService
    {
        private IDatabaseFileManager _databaseFileManager;
        public ConfigurationService(IDatabaseFileManager databaseFileManager)
        {
            _databaseFileManager = databaseFileManager;
        }

        public bool SetSavefilePath(string fullpathToSavefile, bool createIfFileDne)
        {
            return _databaseFileManager.OpenFile(fullpathToSavefile, createIfFileDne);
        }

        public bool IsFileLoaded()
        {
            return _databaseFileManager.HasConnectionString;
        }
    }
}
