namespace ProgressTwitter.Database.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using System.Configuration;
    using Repositories;
    using Entities.Base;
    using Contracts;
    using Attributes;

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

        private void DropDB()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoDefaultConnection"].ConnectionString);
            var client = new MongoClient(url);
            client.DropDatabase(url.DatabaseName);
        }
    }

    [CollectionName("Products")]
    public class Product : Entity
    {
        public decimal Price { get; set; }
    }
}
