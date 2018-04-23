using System;
using System.Collections.Generic;
using TaskTracker.Common.DataStrategy;

namespace TaskTracker.Common.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ICacheStrategy<T> cacheStrategy;

        protected IDbStrategy<T> dbStrategy;

        public Repository(ICacheStrategy<T> cacheStrategy, IDbStrategy<T> dbStrategy)
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

        public abstract IEnumerable<T> GetAll();

        public abstract T Delete(string id);

        public abstract T InsertOrUpdate(T entity);
    }
}