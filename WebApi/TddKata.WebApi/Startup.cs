using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(TddKata.WebApi.Startup))]
namespace TddKata.WebApi
{
    public class Startup
    {
        public StandardKernel Kernel { get; } = new StandardKernel();

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseNinjectMiddleware(ConfigureKernel)
               .UseNinjectWebApi(httpConfiguration);
        }

        protected virtual StandardKernel ConfigureKernel()
        {
            Kernel.Load(Assembly.GetExecutingAssembly());
            return Kernel;
        }
    }
}