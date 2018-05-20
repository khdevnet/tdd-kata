using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using TddKata.WebApi.Comparers;
using TddKata.WebApi.Data.Entities;
using WebApiTddKata.Tests;
using Xunit;

namespace TddKata.WebApi.Tests.Controllers
{
    public class ProductsControllerTests : IntegrationTestsBase
    {
        [Fact]
        public void GetTest()
        {
            var response = httpClient.GetAsync("/api/products").Result;
            Assert.Equal(10, ToResult<IEnumerable<Product>>(response.Content).Count());
        }

        [Fact]
        public void AddTest()
        {
            var expected = new Product(11, "Product-11", 110);
            var response = httpClient.PostAsync("/api/products", expected, new JsonMediaTypeFormatter()).Result;
            Assert.Equal(expected, ToResult<Product>(response.Content), new ProductComparer());
        }

        [Fact]
        public void EditTest()
        {
            var expected = new Product(2, "ProductPut-11", 210);
            var response = httpClient.PutAsync("/api/products/2", expected, new JsonMediaTypeFormatter()).Result;
            Assert.Equal(expected, ToResult<Product>(response.Content), new ProductComparer());
        }
    }
}