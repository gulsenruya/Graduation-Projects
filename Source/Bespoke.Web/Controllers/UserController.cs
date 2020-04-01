using Bespoke.Manager.DatabaseAccess.User;
using Bespoke.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bespoke.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager manager;

        public UserController()
        {
            manager = new UserManager();
        }

        // GET: User
        public ActionResult Index(bool? Success, bool? SuccessUpdated, bool? SuccessRemoved)
        {
            var model = new UserModel
            {
                Users = manager.Gets()
            };

            if (Success.HasValue)
            {
                model.Message = "Added New User";
            }

            if (SuccessUpdated.HasValue)
            {
                model.Message = "Updated Current User";
            }

            if (SuccessRemoved.HasValue)
            {
                model.Message = "Removed User";
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            var db = new Bespoke.Data.Model.BespokeDbEntities();
            model.Branches = this.GetSelectListItems(db.Branches.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            model.User.IsActive = true;

            model.User.UserTypeId = 4;
            model.User.BranchId = Convert.ToInt32(model.SelectedBranch);

            manager.Insert(model.User);

            return RedirectToAction("Index", "User", new { Success = true });

        }

        public ActionResult Update(int id)
        {
            var model = new UserModel
            {
                User = manager.Get(id)
            };
            var db = new Bespoke.Data.Model.BespokeDbEntities();
            model.Branches = this.GetSelectListItems(db.Branches.ToList());
            model.SelectedBranch = model.User.BranchId.ToString();

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserModel model)
        {
            model.User.BranchId = Convert.ToInt32(model.SelectedBranch);
            manager.Update(model.User);

            return RedirectToAction("Index", "User", new { Success = false, SuccessUpdated = true });
        }

        public ActionResult Remove(int id)
        {
            manager.Delete(id);

            return RedirectToAction("Index", "User", new { Success = false, SuccessUpdated = false, SuccessRemoved = true });
        }

        private List<SelectListItem> GetSelectListItems(List<Data.Model.Branch> elements)
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