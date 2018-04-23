using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
//using TaskTracker.Services.Tasks.InMemory;
using TaskTracker.Common.Models;

namespace TaskTracker.Services.Tasks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<InMemoryDataContext<TaskModel>>(opt => opt.UseInMemoryDatabase("inmemory"));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var context = app.ApplicationServices.GetService<InMemoryDataContext<TaskModel>>();
            //AddTestData(context);

            app.UseMvc();
        }

        // private static void AddTestData(InMemoryDataContext<TaskModel> context)
        // {
        //     var testModel = new TaskModel
        //     {
        //         TaskName = "Test Task",
        //         TaskDescription = "Test Description",
        //         CreatedDate = DateTime.Now
        //     };
 
        //     //context.Posts.Add(testModel);
 
        //     context.SaveChanges();
        // }
    }
}
