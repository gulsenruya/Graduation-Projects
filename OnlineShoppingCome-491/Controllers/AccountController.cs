using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OnlineShoppingCome_491.Identity;
using OnlineShoppingCome_491.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCome_491.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                //register process
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı oluştu kullanıcıya bir role ata
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                }
                return RedirectToAction("Login", "Account");

            }
            else
            {
                ModelState.AddModelError("RegisterUserError", "User Creation Error");

            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,String ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login process
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent= model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    if(String.IsNullOrEmpty(ReturnUrl))
                     {
                        return Redirect(string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl);

                    }

                    return RedirectToAction("Index", "Home");                                 
              
                }
                else
                {
                    return RedirectToAction("Account", "Login");
                 
                }
            }   
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}