using System;
using System.Collections.Generic;

namespace TaskTracker.Common.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Delete(string id);
        T GetById(string id);
        T InsertOrUpdate(T entity);
    }
}