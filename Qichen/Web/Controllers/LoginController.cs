using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            KitchenEntities db = new KitchenEntities();
            bool IsValidUser = db.Users.Any(user => user.User_Login.ToLower() ==
             model.UserLogin && user.User_Password == model.Password);
            if (IsValidUser)
            {
                User user = db.Users.Where(tempik => tempik.User_Login == model.UserLogin).FirstOrDefault();
                string userData = string.Format("{0}|{1}|{2}", model.UserLogin, model.Password, user.User_Email);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserLogin, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                FormsAuthentication.SetAuthCookie(model.UserLogin, false);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel ulog)
        {
            KitchenEntities db = new KitchenEntities();
            User tempUser = db.Users.Where(model => model.User_Login == ulog.Login || model.User_Login == ulog.Email).FirstOrDefault();
            if (tempUser == null)
            {
                User user = new User();
                user.User_Email = ulog.Email;
                user.User_Login = ulog.Login;
                user.User_Password = ulog.Password;
                user.User_Adres = ulog.AdressName;

                db.Users.Add(user);
                db.SaveChanges();

                UserRole role = new UserRole();
                role.User_ID = user.User_ID;
                role.Role_ID = 2;
                db.UserRoles.Add(role);

                db.SaveChanges();
                return RedirectToAction("Login", "Login", ulog);
            }
            return View("login", ulog);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}