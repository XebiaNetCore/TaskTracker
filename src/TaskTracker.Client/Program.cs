using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace TaskTracker.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("http://localhost:2000");

            // 1. without access_token will not access the service
            //    and return 401 .
            var resWithoutToken = client.GetAsync("/tasks/1").Result;

            Console.WriteLine($"Sending Request to /tasks/1 , without token.");
            Console.WriteLine($"Result : {resWithoutToken.StatusCode}");

            //2. with access_token will access the service
            //   and return result.
            client.DefaultRequestHeaders.Clear();
            Console.WriteLine("\nBegin Auth....");
            var jwt = GetJwt();
            Console.WriteLine("End Auth....");
            Console.WriteLine($"\nToken={jwt}");

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
            var resWithToken = client.GetAsync("/tasks/1").Result;

            Console.WriteLine($"\nSend Request to /tasks/1 , with token.");
            Console.WriteLine($"Result : {resWithToken.StatusCode}");
            Console.WriteLine(resWithToken.Content.ReadAsStringAsync().Result);

            //3. visit no auth service 
            Console.WriteLine("\nNo Auth Service Here ");
            client.DefaultRequestHeaders.Clear();
            var res = client.GetAsync("/tasks").Result;

            Console.WriteLine($"Send Request to /tasks");
            Console.WriteLine($"Result : {res.StatusCode}");
            Console.WriteLine(res.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }

        private static string GetJwt()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri( "http://localhost:6000");
            client.DefaultRequestHeaders.Clear();

            var res2 = client.GetAsync("/api/auth?name=wow&pwd=123").Result;

            var jwt = res2.Content.ReadAsStringAsync().Result;

            return jwt;
        }
    }
}
