using System;
using System.Collections.Generic;
using TaskTracker.Common.Cache;
using TaskTracker.Common.DataStore;

namespace TaskTracker.Common.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ICache<T> cacheStrategy;

        protected IDataStore<T> dataStoreStrategy;

        public Repository(ICache<T> cacheStrategy, IDataStore<T> dataStoreStrategy)
        {
            this.cacheStrategy = cacheStrategy;
            this.dataStoreStrategy = dataStoreStrategy;
        }

        public T GetById(string id)
        {
            var item = this.cacheStrategy.Get(id);
            if (item != null)
            {
                return item;
            }

            item = this.dataStoreStrategy.GetById(id);
            this.cacheStrategy.InsertOrUpdate(item);

            return item;
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Delete(string id)
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