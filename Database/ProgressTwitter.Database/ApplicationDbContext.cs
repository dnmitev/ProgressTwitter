using AspNet.Identity.MongoDB;
using MongoDB.Driver;
using ProgressTwitter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace ProgressTwitter.Database
{
    public class ApplicationDbContext : IDisposable
    {
        public static ApplicationDbContext Create()
        {
            // todo add settings where appropriate to switch server & database in your own application
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDefaultConnection"].ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["Database_Name"]);
            var users = database.GetCollection<User>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationDbContext(users, roles);
        }

        private ApplicationDbContext(IMongoCollection<User> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<User> Users { get; set; }

        public IMongoCollection<Tweet> Tweets { get; set; }

        public IMongoCollection<FavouriteTwitterUser> FavouriteTwitterUsers { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}
