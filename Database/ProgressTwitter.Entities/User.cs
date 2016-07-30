using AspNet.Identity.MongoDB;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProgressTwitter.Entities
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public int RetweetsCount { get; set; }

        public int DowloadedTweets { get; set; }

        public ICollection<FavouriteTwitterUser> FavouritesList { get; set; }
    }
}
