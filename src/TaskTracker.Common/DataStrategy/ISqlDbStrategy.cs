using System;

namespace TaskTracker.Common.DataStrategy
{
    public interface ISqlDbStrategy<T> : IDbStrategy<T> where T : class
    {
         
    }
}