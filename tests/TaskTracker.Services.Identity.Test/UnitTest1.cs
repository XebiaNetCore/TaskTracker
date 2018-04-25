using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskTracker.Services.Identity.Test
{
    public class UnitTest1
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTest1()
        {
             var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(@"../../.."))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration));
            _client = _server.CreateClient();
        }

        [Fact]
        public async void TokenGenerationTest()
        {
           var response  = await _client.GetAsync("/api/Auth?name=wow&pwd=123");
           Assert.Equal(HttpStatusCode.OK,response.StatusCode);
           var content = response.Content.ReadAsStringAsync().Result;
           Assert.NotNull(content);
           response = await _client.GetAsync("/api/Auth");
           Assert.Equal(HttpStatusCode.Unauthorized,response.StatusCode);
        }
    }
}
