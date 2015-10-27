using Ninject.Modules;
using Parakeet.Services;

namespace Parakeet.Ui
{
    class NInjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ISimpleService>().To<SimpleService>();
            Bind<ISimpleServiceTwo>().To<SimpleServiceTwo>();
        }
    }
}
