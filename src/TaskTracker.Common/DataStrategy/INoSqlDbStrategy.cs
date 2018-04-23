using System;
using TaskTracker.Common.Repository;

namespace TaskTracker.Common.DataStrategy
{
    public interface INoSqlDbStrategy<T> : IDbStrategy<T> where T : class
    {
        
    }
}