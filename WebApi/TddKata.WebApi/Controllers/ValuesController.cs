using System;
using System.Collections.Generic;
using System.Web.Http;
using TddKata.WebApi.Extensibility.Repositories;

namespace TddKata.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IHelloRepository helloRepository;

        public ValuesController(IHelloRepository helloRepository)
        {
            this.helloRepository = helloRepository;
        }

        public IEnumerable<string> Get()
        {
            Console.WriteLine("IEnumerable");
            return helloRepository.Get();
        }
    }
}