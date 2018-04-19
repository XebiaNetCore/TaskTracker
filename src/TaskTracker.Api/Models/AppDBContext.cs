using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Api.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Microservice> Microservices{get;set;}
    }
}