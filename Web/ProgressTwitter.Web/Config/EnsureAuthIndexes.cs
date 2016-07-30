namespace ProgressTwitter.Web
{
    using AspNet.Identity.MongoDB;
    using ProgressTwitter.Database;

    public class EnsureAuthIndexes
	{
		public static void Exist()
		{
			var context = ApplicationDbContext.Create();
			IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
			IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
		}
	}
}