using Microsoft.Owin.Testing;
using Ninject;
using Owin;
using System;
using System.Net.Http;
using TddKata.WebApi;

namespace WebApiTddKata.Tests
{
    public abstract class IntegrationTestsBase : IDisposable
    {
        protected readonly TestServer server;
        protected readonly HttpClient httpClient;
        protected readonly StandardKernel kernel;

        public IntegrationTestsBase()
        {
            var startup = new Startup();
            kernel = startup.Kernel;
            server = TestServer.Create((IAppBuilder app) =>
           {
               startup.Configuration(app);
           });
            httpClient = server.HttpClient;
        }

        protected TResult ToResult<TResult>(HttpContent content)
        {
            return content.ReadAsAsync<TResult>().Result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                server?.Dispose();
                kernel?.Dispose();
            }
        }
    }
}