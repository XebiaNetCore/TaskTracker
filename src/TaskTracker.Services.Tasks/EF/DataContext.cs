using System;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Common.Models;

namespace TaskTracker.Services.Tasks.EF
{
    public class DataContext : DbContext
    {
        // public DataContext(DbContextOptions<DataContext> options) : base(options)
        // {
            
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("inmemorydb");
            //optionsBuilder.UseSqlite("Data Source=sql.db");
        }

        public DbSet<TaskModel> tasks { get; set; }

        public DbSet<FeatureModel> features { get; set; }

        public DbSet<ProjectModel> projects { get; set; }

        public DbSet<SprintModel> sprints { get; set; }
        
        public DbSet<UserModel> users { get; set; }
    }
}