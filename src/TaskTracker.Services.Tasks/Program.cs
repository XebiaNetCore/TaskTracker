using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TaskTracker.Services.Tasks.EF;
using TaskTracker.Common.Models;
using TaskTracker.Services.Tasks.DataStrategy;

namespace TaskTracker.Services.Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            using(var dbContext = new DataContext())
            {
                var testModel = new TaskModel
                {
                    TaskName = "Test Task",
                    TaskDescription = "Test Description",
                    CreatedDate = DateTime.Now
                };
 
                dbContext.tasks.Add(testModel);
 
                dbContext.SaveChanges();

                foreach(var task in dbContext.tasks)
                {
                    Console.WriteLine(task.TaskName + "\n" + task.TaskDescription + "\n" + task.CreatedDate.Date);
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
