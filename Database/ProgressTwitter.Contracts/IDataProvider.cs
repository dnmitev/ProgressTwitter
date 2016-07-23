//namespace ProgressTwitter.Contracts
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;

//    public interface IDataProvider
//    {
//        IQueryable<T> GetAll<T>() where T : class, IEntity<string>;

//        T GetById<T>(object id) where T : class, IEntity<string>;

//        T Add<T>(T entity) where T : class, IEntity<string>;

//        void Add<T>(IEnumerable<T> entities) where T : class, IEntity<string>;

//        T Update<T>(T entity) where T : class, IEntity<string>;

//        void Update<T>(IEnumerable<T> entities) where T : class, IEntity<string>;

//        void Delete<T>(object id) where T : class, IEntity<string>;

//        void Delete<T>(T entity) where T : class, IEntity<string>;

//        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity<string>;

//        void DeleteAll<T>() where T : class, IEntity<string>;

//        long Count<T>() where T : class, IEntity<string>;

//        bool Exists<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity<string>;
//    }
//}
