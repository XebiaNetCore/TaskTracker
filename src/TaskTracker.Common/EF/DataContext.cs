using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<FeatureModel> Feature { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<FeatureModel> Sprint { get; set; }
        public DbSet<ProjectModel> Task { get; set; }
        public DbSet<FeatureModel> User { get; set; }
    }
}