//namespace ProgressTwitter.Database.UoW
//{
//    using Contracts;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;
//    using System.Linq.Expressions;
//    using Entities.Base;
//    using Repositories;

//    public class MongoDataProvider : IDataProvider
//    {
//        private string collectionName;
//        private IDictionary<Type, object> createdRepositories;

//        public  void IDataProvider.Add<T>(IEnumerable<T> entities)
//        {
//            this.GetRepository<T>().Add(entities);
//        }

//        public T IDataProvider.Add<T>(T entity)
//        {
//            return this.GetRepository<T>().Add(entity);
//        }

//        public long IDataProvider.Count<T>()
//        {
//            return this.GetRepository<T>().Count();
//        }

//        public void IDataProvider.Delete<T>(T entity)
//        {
//            this.GetRepository<T>().Delete(entity);
//        }

//        public void IDataProvider.Delete<T>(Expression<Func<T, bool>> predicate)
//        {
//            this.GetRepository<T>().Delete(predicate);
//        }

//        public void IDataProvider.Delete<T>(object id)
//        {
//            this.GetRepository<T>().Delete(id.ToString());
//        }

//        public void IDataProvider.DeleteAll<T>()
//        {
//            this.GetRepository<T>().DeleteAll();
//        }

//        public bool IDataProvider.Exists<T>(Expression<Func<T, bool>> predicate)
//        {
//            return this.GetRepository<T>().Exists(predicate);
//        }

//        public IQueryable<T> IDataProvider.GetAll<T>()
//        {
//            return this.GetRepository<T>().GetAll();
//        }

//        public T IDataProvider.GetById<T>(object id)
//        {
//            return this.GetRepository<T>().GetById(id.ToString());
//        }

//        public void IDataProvider.Update<T>(IEnumerable<T> entities)
//        {
//            this.GetRepository<T>().Update(entities);
//        }

//        public T IDataProvider.Update<T>(T entity)
//        {
//            return this.GetRepository<T>().Update(entity);
//        }

//        private IRepository<T> GetRepository<T>() where T : class, IEntity<string>
//        {
//            var typeOfRepository = typeof(T);

//            if (!this.createdRepositories.ContainsKey(typeOfRepository))
//            {
//                var newRepository = Activator.CreateInstance(typeof(MongoRepository<T>));

//                this.createdRepositories.Add(typeOfRepository, newRepository);
//            }

//            return (IRepository<T>)this.createdRepositories[typeOfRepository];
//        }
//    }
//}
