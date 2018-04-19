using System;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Common.EF
{
    public interface IDataContext<T> where T : class
    {
        DbSet<T> dbSet { get; set; } 
    }
}