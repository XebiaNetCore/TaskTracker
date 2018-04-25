using System;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Services.Identity.Model;

namespace TaskTracker.Services.Identity.DbRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Registration> Registration { get; set; }
    }
}