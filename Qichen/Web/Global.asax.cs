using Domain;
using Qichen.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // get the cookie
            HttpCookie authCookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (authCookie != null)
            {
                // get the ticket
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string[] udata = ticket.UserData.Split('|');
                UsersRoleProvider usersRoleProvider = new UsersRoleProvider();
                string[] temp = usersRoleProvider.GetRolesForUser(udata[0]);
                FormsIdentity identity = new FormsIdentity(ticket);
                GenericPrincipal gIdentity = new GenericPrincipal(identity, temp);
                HttpContext.Current.User = gIdentity;


                //// Usage:
                //string name = udata[0];
                //bool isAuthenticated = true;
                //string profilePicture = udata[3];
                //CustomIdentity customIdentity = new CustomIdentity(name, isAuthenticated, profilePicture);
                //GenericPrincipal customPrincipal = new GenericPrincipal(customIdentity, temp);
                //HttpContext.Current.User = customPrincipal;
            }
        }
    }
}
