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
using TaskTracker.Services.Tasks;

namespace TaskTracker.Services.Task.Test
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
        public async void GetAllTasks()
        {
            var response = await _client.GetAsync("/api/Task");
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var taskArray = JArray.Parse(content);
            Assert.Equal(true, taskArray.Count == 2);
        }
    }
}
