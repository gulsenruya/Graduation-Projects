using Bespoke.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bespoke.Web.Model
{
    public class MenuModel
    {
        public string Message { get; set; }
        public int BranchId { get; set; }
        public int BranchMenuId { get; set; }

        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string Intro { get; set; }
    }
}