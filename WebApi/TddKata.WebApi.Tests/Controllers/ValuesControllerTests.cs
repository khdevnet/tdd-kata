using Microsoft.Owin.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace TddKata.WebApi.Tests.Controllers
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetTest()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var response = server.HttpClient.GetAsync("/api/values").Result;
                IEnumerable<string> result = response.Content.ReadAsAsync<IEnumerable<string>>().Result;

                Assert.Equal(2, result.Count());
                Assert.Equal("Hi", result.First());
                Assert.Equal("Anton", result.Last());
            }
        }
    }
}