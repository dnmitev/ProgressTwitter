namespace ProgressTwitter.Database.Tests
{
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using Repositories;
    using System.Configuration;
    using System.Linq;

    [TestClass]
    public class MongoRepositoryTests
    {
        private IRepository<Product> repo;

        [TestInitialize]
        public void Setup()
        {
            // to be sure that each time the DB is created by the repository
            // no old DB  left
            this.DropDB();

            this.repo = new MongoRepository<Product>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.DropDB();
        }

        [TestMethod]
        public void ShouldCreateCollectionWithTheClassName()
        {
            repo = new MongoRepository<Product>();
            Assert.AreEqual(repo.Collection.CollectionNamespace.CollectionName, "Products");
        }

        [TestMethod]
        public void ShoudlAddOneItemToCollection()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            Assert.AreEqual(1, repo.GetAll().Count());
        }

        [TestMethod]
        public void ShoudlGenerateIdAutomaticallyOnAdd()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            Assert.IsInstanceOfType(repo.GetAll().FirstOrDefault().Id, typeof(string));
        }


        [TestMethod]
        public void ShoudlAddManyItems()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            Assert.AreEqual(10, repo.GetAll().Count());
        }

        [TestMethod]
        public void ShoudGetItemById()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            var item = repo.GetAll().FirstOrDefault();
            var actual = repo.GetById(item.Id);

            Assert.AreEqual(item.Id, actual.Id);
        }

        [TestMethod]
        public void ShoudDeleteItemById()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            var item = repo.GetAll().FirstOrDefault();
            repo.Delete(item.Id);

            Assert.AreEqual(0, repo.GetAll().Count());
        }

        [TestMethod]
        public void ShoudDeleteItem()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            var item = repo.GetAll().FirstOrDefault();
            repo.Delete(item);

            Assert.AreEqual(0, repo.GetAll().Count());
        }

        [TestMethod]
        public void ShoudlDeleteAll()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            repo.DeleteAll();

            Assert.AreEqual(0, repo.GetAll().Count());
        }

        [TestMethod]
        public void ShouldDeleteByCondition()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            repo.Delete(p => p.Price > 7);

            Assert.AreEqual(8, repo.Count());
        }

        [TestMethod]
        public void ShoudlUpdateMultipleItem()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            var items = repo.GetAll();
            foreach (var item in items)
            {
                item.Price += 1000;
            }

            repo.Update(items);

            var actual = repo.GetAll();

            var isUpdated = true;
            foreach (var item in actual)
            {
                isUpdated = item.Price < 1000 ? false : true;
            }

            Assert.IsTrue(isUpdated);
        }


        [TestMethod]
        public void ShoudlUpdateItem()
        {
            repo = new MongoRepository<Product>();
            repo.Add(new Product() { Price = 10 });

            var item = repo.GetAll().FirstOrDefault();
            item.Price = 102;

            repo.Update(item);

            Assert.AreEqual(item.Price, repo.GetById(item.Id).Price);
        }

        [TestMethod]
        public void ShoudlHaveCount()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            Assert.AreEqual(10, repo.Count());
        }

        [TestMethod]
        public void ShouldReturnTrueIfExists()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            Assert.IsTrue(repo.Exists(p => p.Price > 5));
        }

        [TestMethod]
        public void ShouldReturnFalseIfDoesNoExist()
        {
            repo = new MongoRepository<Product>();
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Product() { Price = i });
            }

            Assert.IsTrue(repo.Exists(p => p.Price > 10));
        }

        private void DropDB()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoDefaultConnection"].ConnectionString);
            var client = new MongoClient(url);
            client.DropDatabase(url.DatabaseName);
        }
    }
}
