using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TddKata.WebApi.Data.Entities;
using TddKata.WebApi.Extensibility.Data.Repositories;

namespace TddKata.WebApi.Data.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        public List<Product> Products { get; } = GetSampleProducts().ToList();

        public Product Add(Product product)
        {
            var p = new Product(
                    Products.Last().Id + 1,
                    product.Name,
                    product.Price);

            Products.Add(p);

            return p;
        }

        public IEnumerable<Product> Get()
        {
            return Products;
        }

        public Product Get(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        private static IEnumerable<Product> GetSampleProducts()
        {
            var products = new Collection<Product>();
            for (var i = 1; i <= 10; i++)
            {
                products.Add(new Product(i, $"Product-{i}", i * 10));
            }
            return products;
        }

        public Product Edit(int id, Product product)
        {
            var current = Get(id);
            var currentIndex = Products.IndexOf(current);
            Products.RemoveAt(currentIndex);

            var updatedProduct = new Product(id, product.Name, product.Price);
            Products.Insert(currentIndex, updatedProduct);

            return updatedProduct;
        }
    }
}