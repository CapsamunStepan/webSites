using Qitchen.BusinessLogic.Service;
using Qitchen.Domain.Entities;
using Qitchen.Filters;
using Qitchen.Web.Extensions;
using Qitchen.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Qitchen.Web.Controllers
{
    public class PagesController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                using (var authService = new AuthService())
                {
                    var data = new AuthService.LoginData()
                    {
                        Email = form.Email,
                        Password = form.Password,
                        IpAddress = Request.UserHostAddress,
                        Time = DateTime.Now
                    };

                    var loginResp = authService.Login(data);
                    if (loginResp.Success)
                    {
                        var session = loginResp.Entry;

                        // Create Cookie.
                        var cookie = new HttpCookie(SESSION_COOKIE_NAME, session.Token);
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cookie);

                        return Redirect("/");
                    }

                    ModelState.AddModelError("Password", loginResp.Message);
                }
            }

            return View(form);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                using (var authService = new AuthService())
                {
                    var data = new AuthService.RegisterData()
                    {
                        Name = form.Name,
                        Email = form.Email,
                        Password = form.Password,
                        IpAddress = Request.UserHostAddress,
                        Time = DateTime.Now
                    };

                    var loginStatus = authService.Register(data);
                    if (loginStatus.Success)
                    {
                        return Login(new LoginForm 
                        { 
                            Email = form.Email,
                            Password = form.Password,
                        });
                    }

                    ModelState.AddModelError("", loginStatus.Message);
                }
            }

            return View(form);
        }

        public ActionResult Logout()
        {
            // Clear session cookie.
            var cookie = Request.Cookies[SESSION_COOKIE_NAME];
            if (cookie != null)
            {
                // Force expire.
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Session.ClearUser();
            return Redirect("/");
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Err404()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Chefs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult MenuFastFood()
        {
            return View();
        }
        public ActionResult MenuSeaFood()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        [RequireUserRole(UserRole.User)]
        public ActionResult Reservations()
        {
            return View();
        }

    }
}