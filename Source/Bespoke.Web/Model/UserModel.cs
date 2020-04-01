using Bespoke.Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bespoke.Web.Model
{
    public class UserModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public List<SelectListItem> Branches { get; set; }
        public string SelectedBranch { get; set; }
    }
}