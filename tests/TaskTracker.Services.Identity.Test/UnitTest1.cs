using JWT;
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
            .AddJsonFile("appSettings.json",optional:false)
            .Build();
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration));
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task TestIfUnauthorizedAccess()
        {
            var response=await _client.GetAsync("api/account");
            Assert.Equal(HttpStatusCode.Unauthorized,response.StatusCode);
        }
        [Fact]
        public async Task GetAccessToken()
        {
            var body=@"{Email:""ssrivastava@xebia.com"",password:""admin@123""}";
            var response=await _client.PostAsync("api/token",new StringContent(body,Encoding.UTF8,"application/json"));
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);//check if status code is 200
            
            var responseStr=await response.Content.ReadAsStringAsync();
            var json=JObject.Parse(responseStr);
            Assert.NotNull((string)json["token"]);
        }
        [Fact]
        public async Task GetAllTasksList()
        {
            var body=@"{Email:""ssrivastava@xebia.com"",password:""admin@123""}";
            var response=await _client.PostAsync("api/token",new StringContent(body,Encoding.UTF8,"application/json"));
            var responseStr=await response.Content.ReadAsStringAsync();
            var json=JObject.Parse(responseStr);
            var token = (string)json["token"];
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/account");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var tasksResponse = await _client.SendAsync(requestMessage);

            Assert.Equal(HttpStatusCode.OK, tasksResponse.StatusCode);

            var taskResponseString = await tasksResponse.Content.ReadAsStringAsync();
            var taskResponseJson = JArray.Parse(taskResponseString);
            Assert.Equal(true, taskResponseJson.Count == 4);
        }
    }
}
