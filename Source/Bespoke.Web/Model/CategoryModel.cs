using Bespoke.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bespoke.Web.Model
{
    public class CategoryModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public string Message { get; set; }
    }
}