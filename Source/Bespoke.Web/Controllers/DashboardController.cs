using Bespoke.Data.Model;
using Bespoke.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bespoke.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var session = (User)Session["Active-User"];

            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = new DashboardModel
                {
                    ActiveUser = session
                };

                return View(model);
            }
        }
    }
}