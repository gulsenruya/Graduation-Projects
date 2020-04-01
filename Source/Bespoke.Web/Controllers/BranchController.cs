using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Bespoke.Manager.DatabaseAccess.Branch;
using Bespoke.Web.Model;
using System.Linq;

namespace Bespoke.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly BranchManager manager;
        private readonly CategoryManager categoryManager;

        public BranchController()
        {
            manager = new BranchManager();
            categoryManager = new CategoryManager();
        }

        public ActionResult Index(bool? Success, bool? SuccessUpdated, bool? SuccessRemoved)
        {
            var model = new BranchModel
            {
                Branches = this.manager.Gets()
            };

            if (Success.HasValue)
            {
                model.Message = "Added New Branch";
            }

            if (SuccessUpdated.HasValue)
            {
                model.Message = "Updated Current Branch";
            }

            if (SuccessRemoved.HasValue)
            {
                model.Message = "Removed Branch";
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new BranchModel());
        }

        [HttpPost]
        public ActionResult Create(BranchModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var folder = HttpContext.Server.MapPath("~/Assets/branchlogos");

                var path = Path.Combine(folder, file.FileName);

                file.SaveAs(path);

                model.Branch.Since = DateTime.Now;

                model.Branch.Logo = file.FileName;

                manager.Insert(model.Branch);
            }
            else
            {
                model.Message = "Please Select Your Logo";
                return View(model);
            }

            return RedirectToAction("Index", "Branch", new { Success = true });
        }

        public ActionResult Update(int id)
        {
            var model = new BranchModel
            {
                Branch = manager.Get(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(BranchModel model, HttpPostedFileBase file)
        {
            if (file == null)
            {
                var savedImageName = manager.Get(model.Branch.Id).Logo;
                model.Branch.Logo = savedImageName;
            }
            else
            {
                var folder = HttpContext.Server.MapPath("~/Assets/branchlogos");

                var path = Path.Combine(folder, file.FileName);

                file.SaveAs(path);

                model.Branch.Logo = file.FileName;

                manager.Update(model.Branch);
            }

            return RedirectToAction("Index", "Branch", new { Success = false, SuccessUpdated = true });
        }

        public ActionResult Remove(int id)
        {
            manager.Delete(id);

            return RedirectToAction("Index", "Branch", new { Success = false, SuccessUpdated = false, SuccessRemoved = true });
        }

        public ActionResult Categories(int id, bool? Success, bool? SuccessUpdated, bool? SuccessRemoved)
        {
            var user = (Data.Model.User)Session["Active-User"];

            var model = new CategoryModel
            {
                Category = new Data.Model.Category(),
                Message = string.Empty,
                Categories = categoryManager.Gets().Where(x => x.BranchId == id).ToList()
            };
            
            if (Success.HasValue)
            {
                model.Message = "Added New Category";
            }

            if (SuccessUpdated.HasValue)
            {
                model.Message = "Updated Current Category";
            }

            if (SuccessRemoved.HasValue)
            {
                model.Message = "Removed Category";
            }

            return View(model);
        }

        public ActionResult CreateCategory(int id)
        {
            var model = new CategoryModel();

            model.Category = new Data.Model.Category
            {
                BranchId = id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryModel model)
        {
            if (string.IsNullOrEmpty(model.Category.Name))
            {
                model.Message = "Please Set Your Category Name";
                return View(model);
            }
            else
            {
                model.Category.IsActive = true;
                categoryManager.Insert(model.Category);
            }

            return RedirectToAction("Categories", "Branch", new { id = model.Category.BranchId, Success = true });
        }

        public ActionResult UpdateCategory(int id) //0111111123213123XAAAAAbbbb77001
        {
            var model = new CategoryModel
            {
                Category = categoryManager.Get(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryModel model)
        {
            categoryManager.Update(model.Category);

            return RedirectToAction("Categories", "Branch", new { id = model.Category.BranchId, Success = false, SuccessUpdated = true });
        }

        public ActionResult RemoveCategory(int id)
        {
            var savedRecord = categoryManager.Get(id);

            categoryManager.Delete(id);

            return RedirectToAction("Categories", "Branch", new { id = savedRecord.BranchId, Success = false, SuccessUpdated = false, SuccessRemoved = true });
        }
    }
}