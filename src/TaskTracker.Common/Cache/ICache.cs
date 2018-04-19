using System;

namespace TaskTracker.Common.Cache
{
    public interface ICache<T> where T : class
    {
        bool InsertOrUpdate(T entity);
        T Get(string id);
        bool Invalidate(string id);
    }
}