using Ninject.Modules;
using System.Collections.Generic;

using TddKata.WebApi.Comparers;
using TddKata.WebApi.Data.Entities;
using TddKata.WebApi.Data.Repositories;
using TddKata.WebApi.Extensibility.Data.Repositories;

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
            Kernel.Bind<IProductsRepository>().To<ProductsRepository>();
            Kernel.Bind<IEqualityComparer<Product>>().To<ProductComparer>();
        }
    }
}