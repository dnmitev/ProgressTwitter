namespace ProgressTwitter.Database.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using System.Configuration;

    [TestClass]
    public class MongoRepositoryTests
    {
        [TestInitialize]
        public void Setup()
        {
            // to be sure that each time the DB is created by the repository
            // no old DB  left
            this.DropDB();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.DropDB();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        private void DropDB()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoDefaultConnection"].ConnectionString);
            var client = new MongoClient(url);
            client.DropDatabase(url.DatabaseName);
        }
    }
}
