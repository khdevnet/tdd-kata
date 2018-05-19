using System.Collections.Generic;

namespace TddKata.WebApi.Extensibility.Repositories
{
    public interface IHelloRepository
    {
        IEnumerable<string> Get();
    }
}