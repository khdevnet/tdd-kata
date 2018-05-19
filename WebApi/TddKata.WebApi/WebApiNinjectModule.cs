using Ninject.Modules;
using TddKata.WebApi.Extensibility.Repositories;
using TddKata.WebApi.Repositories;

namespace TddKata.WebApi
{
    public class WebApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Kernel.Bind<IHelloRepository>().To<HelloRepository>();
        }
    }
}