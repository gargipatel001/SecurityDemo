using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LoginAssignment.Startup))]

namespace LoginAssignment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = SecurityDemo; Integrated Security = SSPI;";
            const string connectionString = @"Data Source=LAPTOP-2BLG4G2C\GARGI_SQLSERVER;Initial Catalog=SecurityDemo;Integrated Security=SSPI;";
            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));
            app.CreatePerOwinContext<UserManager<IdentityUser>>((opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));
            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>(
                (opt, cont) =>
                    new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));

           
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
