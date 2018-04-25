using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskTracker.Services.Identity.DbRepository;
using TaskTracker.Services.Identity.Security;

namespace TaskTracker.Services.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost,1401";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Pa$$w0rd@123";
            var connString = $"Data Source={hostname};Initial Catalog=Account;User ID=SA;Password={password};";
            Console.WriteLine(connString);
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connString));
            var t = Configuration.GetSection("Jwt");
            var s = t["Issuer"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            services.Configure<JwtIssuerOptions>(option =>
            {
                option.Issuer = Configuration["Jwt:Issuer"];
                option.Audience = Configuration["Jwt:Issuer"];
                option.SigningCredentials = creds;
            });
            //services.AddDbContext<RepositoryContext>(c => c.UseInMemoryDatabase("Account"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                };
            });
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
