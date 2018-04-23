using System;

namespace TaskTracker.Common.DataStrategy
{
    public interface ICacheStrategy<T> where T : class
    {
        bool InsertOrUpdate(T entity);
        T Get(string id);
        bool Invalidate(string id);
    }
}