using System;
using System.Collections.Generic;
using TaskTracker.Common.DataStore;
using TaskTracker.Common.EF;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Common.DataStore
{
    public class SqlDataStore<T> : IDataStore<T> where T : class
    {
        protected readonly SqliteDataContext<T> dataContext;

        protected readonly DbSet<T> dbSet;

        public SqlDataStore(IDataContext<T> dataContext)
        {
            // Since this is a specific implementation for Sql it does know about the existence of SqlDataContext
            this.dataContext = dataContext as SqliteDataContext<T>;
            this.dbSet = this.dataContext.Set<T>();
        }

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
        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }
        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}