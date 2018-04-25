using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using Ocelot.DependencyInjection;
using CacheManager.Core;
using Ocelot.Middleware;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace TaskTracker.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();  
            builder.SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json")       
               //add configuration.json  
               .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)               
               .AddEnvironmentVariables();  
  
           Configuration = builder.Build(); 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(db => 
                   db.UseInMemoryDatabase("MicroserviceDB"));
            services.AddScoped<IMicroserviceRepository,MicroserviceRepository>();
            services.AddMvc();  
            var audienceConfig = Configuration.GetSection("Audience");  
  
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Key"]));  
        var tokenValidationParameters = new TokenValidationParameters  
        {  
        ValidateIssuerSigningKey = true,  
        IssuerSigningKey = signingKey,  
        ValidateIssuer = true,  
        ValidIssuer = audienceConfig["Issuer"],  
        ValidateAudience = true,  
        ValidAudience = audienceConfig["Aud"],  
        ValidateLifetime = true,  
        ClockSkew = TimeSpan.Zero,  
        RequireExpirationTime = true,  
       };  
  
         services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })  
            .AddJwtBearer("TestKey", x =>  
             {  
                 x.RequireHttpsMetadata = false;  
                 x.TokenValidationParameters = tokenValidationParameters;  
             });  
  
         services.AddOcelot(Configuration);       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            await app.UseOcelot();
           
        }
    }
}
