using System.Collections.Generic;
using TddKata.WebApi.Extensibility.Repositories;

namespace TddKata.WebApi.Repositories
{
    internal class HelloRepository : IHelloRepository
    {
        public IEnumerable<string> Get() => new[] { "Hi", "Anton" };
    }
}