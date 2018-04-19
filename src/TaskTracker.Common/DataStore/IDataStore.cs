using System;
using TaskTracker.Common.Repository;

namespace TaskTracker.Common.DataStore
{
    public interface IDataStore<T> : IRepository<T> where T : class
    {
        
    }
}