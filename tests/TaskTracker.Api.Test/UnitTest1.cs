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

namespace TaskTracker.Api.Test
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
        public async Task GetMicroservicesTest()
        {
           var response = await _client.GetAsync("/api/values");
           Assert.Equal(HttpStatusCode.OK,response.StatusCode);
           var contentString = await response.Content.ReadAsStringAsync();
           var services = JArray.Parse(contentString);
           Assert.Equal(true, services.Count == 1);
        }

        [Fact]
        public async Task GetMicroserviceByIdTest()
        {
           var response = await _client.GetAsync("/api/values/1");
           Assert.Equal(HttpStatusCode.OK,response.StatusCode);
           var contentString = await response.Content.ReadAsStringAsync();
           var service = JObject.Parse(contentString);
           Assert.Equal("Identity", service["name"]);
           response = await _client.GetAsync("/api/values/2");
           Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        }

        [Fact]
        public async Task CreateMicroserviceTest()
        {
            var values = new JObject();
            values.Add("name","Project");
            HttpContent content = new StringContent(values.ToString(), Encoding.UTF8,"application/json");
            var response = await _client.PostAsync("/api/values",content);
            Assert.Equal(HttpStatusCode.Created,response.StatusCode);
            content = new StringContent("",Encoding.UTF8,"application/json");
            response = await _client.PostAsync("/api/values",content);
            Assert.Equal(HttpStatusCode.BadRequest,response.StatusCode);
        }

        [Fact]
        public async Task DeleteMicroserviceTest()
        {
           var response = await _client.DeleteAsync("/api/values/1");
           Assert.Equal(HttpStatusCode.NoContent,response.StatusCode);
           response = await _client.DeleteAsync("/api/values/1");
           Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        }
    }
}
