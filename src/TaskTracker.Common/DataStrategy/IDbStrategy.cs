using System;
using TaskTracker.Common.Repository;

namespace TaskTracker.Common.DataStrategy
{
    public interface IDbStrategy<T> : IRepository<T> where T : class
    {
         
    }
}