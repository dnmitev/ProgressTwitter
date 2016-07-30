namespace ProgressTwitter.Web.Config
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspNet.Identity.MongoDB;

    using Models;
    using MongoDB.Driver;
    using Database.Repositories;
    using System.Configuration;

    public class ApplicationIdentityContext : IDisposable
    {
        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDefaultConnection"].ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["Database_Name"]);
            var users = database.GetCollection<ApplicationUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}