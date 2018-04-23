using System;
using TaskTracker.Common.DataStrategy;

namespace TaskTracker.Services.Tasks.DataStrategy
{
    public class CacheStrategy<T> : ICacheStrategy<T> where T : class
    {
        public bool InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
        public T Get(string id)
        {
            throw new NotImplementedException();
        }
        public bool Invalidate(string id)
        {
            throw new NotImplementedException();
        }
    }
}