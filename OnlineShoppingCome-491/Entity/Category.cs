using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCome_491.Entity
{
    public class Category
    {
        //Data annotations
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [StringLength(maximumLength:20,ErrorMessage="en fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}