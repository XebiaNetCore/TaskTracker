using System;
using TaskTracker.Common.Repository;

namespace TaskTracker.Common.DataStrategy
{
    public interface IInMemoryDbStrategy<T> : IDbStrategy<T> where T : class
    {
         
    }
}