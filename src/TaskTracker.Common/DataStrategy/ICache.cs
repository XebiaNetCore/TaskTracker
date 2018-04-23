using System;

namespace TaskTracker.Common.DataStrategy
{
    public interface ICache<T> where T : class
    {
        bool InsertOrUpdate(T entity);
        T Get(string id);
        bool Invalidate(string id);
    }
}