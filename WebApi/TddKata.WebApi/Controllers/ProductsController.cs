using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using TddKata.WebApi.Data.Entities;
using TddKata.WebApi.Extensibility.Data.Repositories;

namespace TddKata.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IEnumerable<Product> Get()
        {
            return productsRepository.Get();
        }

        [HttpPost]
        public Product Add(Product product)
        {
            return productsRepository.Add(product);
        }

        [HttpPut]
        public IHttpActionResult Edit([FromUri] int id, [FromBody] Product product)
        {
            var current = productsRepository
                 .Get(id);

            if (current == null)
            {
                return NotFound();
            }

            return Ok(productsRepository.Edit(id, product));
        }
    }
}