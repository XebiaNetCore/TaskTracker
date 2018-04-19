using System;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Common.EF
{
    public class SqliteDataContext<T> : DbContext, IDataContext<T> where T : class
    {
        public SqliteDataContext() : base()  
        {  
        }  
  
        public DbSet<T> dbSet { get; set; }  
    }
}