using System.Collections.Generic;
using TddKata.WebApi.Data.Entities;

namespace TddKata.WebApi.Extensibility.Data.Repositories
{
    public interface IProductsRepository
    {
        Product Get(int id);

        IEnumerable<Product> Get();

        Product Add(Product product);

        Product Edit(int id, Product product);
    }
}