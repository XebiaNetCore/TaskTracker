using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

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

           services.AddSwaggerGen(c =>{
               c.SwaggerDoc("v1",new Info{
                   Title = "The Task Microservice",
                   Version = "v1"
               });
           });
  
           services.AddAuthentication(o => {
               o.DefaultAuthenticateScheme = "TestKey";
           })  
            .AddJwtBearer("TestKey",x =>  
             {  
                 x.RequireHttpsMetadata = false;  
                 x.TokenValidationParameters = tokenValidationParameters;  
             });  
  
           services.AddMvc();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>{
               c.SwaggerEndpoint("/swagger/v1/swagger.json","The Task Microservice Swagger Doc");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
