using Bespoke.Data.Model;
using Bespoke.Web.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Bespoke.Web.Controllers
{
    public class BranchesMenusController : Controller
    {
        private BespokeDbEntities db = new BespokeDbEntities();

        // GET: BranchesMenus
        public ActionResult Index(bool? a)
        {
            var model = new List<MenuModel>();
            var user = (Data.Model.User)Session["Active-User"];

            if (user == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                var result = (from bm in db.BranchesMenus.ToList()
                              join c in db.Categories.ToList() on bm.CategoryId equals c.Id
                              join u in db.Users.ToList() on c.BranchId equals u.BranchId
                              where u.Id == user.Id
                              select (new MenuModel()
                              {
                                  BranchId = u.BranchId.Value,
                                  BranchMenuId = bm.Id,
                                  CategoryName = c.Name,
                                  Price = bm.Price.Value,
                                  Name = bm.Name
                              })).ToList();
                model = result;
            }

            if (a.HasValue)
            {
                ViewBag.Message = "Success New Product";
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new MenuModel();
            var user = (Data.Model.User)Session["Active-User"];
            var categories = db.Categories.Where(x => x.BranchId == user.BranchId).ToList();

            model.Categories = GetSelectListItems(categories);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MenuModel item)
        {
            var menu = new Data.Model.BranchesMenu();
            var user = (Data.Model.User)Session["Active-User"];

            menu.CategoryId = Convert.ToInt32(item.SelectedCategory);
            menu.Name = item.Name;
            menu.Intro = item.Intro;
            menu.Price = item.Price;
            menu.IsActive = true;

            db.BranchesMenus.Add(menu);
            db.SaveChanges();

            return RedirectToAction("Index", "BranchesMenus", new { a = true });

        }

        private List<SelectListItem> GetSelectListItems(List<Data.Model.Category> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }

            return selectList;
        }
    }
}
