using Ninject.Modules;
using Parakeet.Services;

namespace Parakeet.Ui
{
    class NInjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseFileService>().To<DatabaseFileService>();
        }
    }
}
