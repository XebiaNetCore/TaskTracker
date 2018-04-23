using System;
using System.Collections.Generic;
using TaskTracker.Common.DataStrategy;

namespace TaskTracker.Common.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ICache<T> cacheStrategy;

        protected IDbStrategy<T> dbStrategy;

        public Repository(ICache<T> cacheStrategy, IDbStrategy<T> dbStrategy)
        {
            this.cacheStrategy = cacheStrategy;
            this.dbStrategy = dbStrategy;
        }

        public T GetById(string id)
        {
            var item = this.cacheStrategy.Get(id);
            if (item != null)
            {
                return item;
            }

            item = this.dbStrategy.GetById(id);
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

        public T InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}