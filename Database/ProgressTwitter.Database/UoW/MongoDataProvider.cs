namespace ProgressTwitter.Database.UoW
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using Entities.Base;
    using Repositories;

    public class MongoDataProvider : IDataProvider
    {
        private string collectionName;
        private IDictionary<Type, object> createdRepositories;

        void IDataProvider.Add<T>(IEnumerable<T> entities)
        {
            this.GetRepository<T>().Add(entities);
        }

        T IDataProvider.Add<T>(T entity)
        {
            return this.GetRepository<T>().Add(entity);
        }

        long IDataProvider.Count<T>()
        {
            return this.GetRepository<T>().Count();
        }

        void IDataProvider.Delete<T>(T entity)
        {
            this.GetRepository<T>().Delete(entity);
        }

        void IDataProvider.Delete<T>(Expression<Func<T, bool>> predicate)
        {
            this.GetRepository<T>().Delete(predicate);
        }

        void IDataProvider.Delete<T>(object id)
        {
            this.GetRepository<T>().Delete(id.ToString());
        }

        void IDataProvider.DeleteAll<T>()
        {
            this.GetRepository<T>().DeleteAll();
        }

        bool IDataProvider.Exists<T>(Expression<Func<T, bool>> predicate)
        {
            return this.GetRepository<T>().Exists(predicate);
        }

        IQueryable<T> IDataProvider.GetAll<T>()
        {
            return this.GetRepository<T>().GetAll();
        }

        T IDataProvider.GetById<T>(object id)
        {
            return this.GetRepository<T>().GetById(id.ToString());
        }

        void IDataProvider.Update<T>(IEnumerable<T> entities)
        {
            this.GetRepository<T>().Update(entities);
        }

        T IDataProvider.Update<T>(T entity)
        {
            return this.GetRepository<T>().Update(entity);
        }

        private IRepository<T> GetRepository<T>() where T : class, IEntity<string>
        {
            var typeOfRepository = typeof(T);

            if (!this.createdRepositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(MongoRepository<T>));

                this.createdRepositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.createdRepositories[typeOfRepository];
        }
    }
}
