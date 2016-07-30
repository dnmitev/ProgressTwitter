using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using ProgressTwitter.Web.Models;
using Owin;
using System;
using Microsoft.Owin.Security;
using ProgressTwitter.Database;
using ProgressTwitter.Entities;
using Microsoft.Owin.Security.Twitter;
using System.Configuration;

namespace ProgressTwitter.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            {
                ConsumerKey = ConfigurationManager.AppSettings["Twitter_Consumer_Key"],
                ConsumerSecret = ConfigurationManager.AppSettings["Twitter_Consumer_Secret"],
                BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
                {
                    ConfigurationManager.AppSettings["VeriSign_Class_3_Secure_Server_CA_G2"], // VeriSign Class 3 Secure Server CA - G2
                    ConfigurationManager.AppSettings["VeriSign_Class_3_Secure_Server_CA_G3"], // VeriSign Class 3 Secure Server CA - G3
                    ConfigurationManager.AppSettings["VeriSign_Class_3_Public"], // VeriSign Class 3 Public Primary Certification Authority - G5
                    ConfigurationManager.AppSettings["Symantec_Class_3_Secure_Server_CA_G4"], // Symantec Class 3 Secure Server CA - G4
                    ConfigurationManager.AppSettings["DigiCert_SHA2_High_Assurance_Server_C‎A"], // DigiCert SHA2 High Assurance Server C‎A 
                    ConfigurationManager.AppSettings["DigiCert_High_Assurance_EV_Root_CA"] // DigiCert High Assurance EV Root CA
                })
            });

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication();
        }
    }
}