using System;
using System.Collections.Generic;
using TaskTracker.Common.DataStrategy;

namespace TaskTracker.Services.Tasks.DataStrategy
{
    public class NoSqlDbStrategy<T> : INoSqlDbStrategy<T> where T : class
    {
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public T Delete(string id)
        {
            throw new NotImplementedException();
        }
        public T GetById(string id)
        {
            throw new NotImplementedException();
        }
        public T InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}