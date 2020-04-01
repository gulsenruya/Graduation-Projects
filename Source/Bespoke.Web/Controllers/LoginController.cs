using Bespoke.Manager.DatabaseAccess.User;
using Bespoke.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bespoke.Web.Controllers
{
    public class LoginController : Controller
    {
        private UserManager manager;

        [HttpGet]
        public ActionResult Index()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            this.manager = new UserManager();

            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                model.TransactionResult = "Lütfen alanları boş bırakmayın.";
            }
            else
            {
                var user = manager.GetLogin(model.Username, model.Password);

                if (user != null)
                {
                    Session["Active-User"] = user;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    model.TransactionResult = "Böyle bir kullanıcı bulunamadı";
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session["Active-User"] = null;

            return RedirectToAction("Index", "Login");
        }
    }
}