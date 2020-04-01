using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingCome_491.Entity;

namespace OnlineShoppingCome_491.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }

        public static implicit operator ProductModel(Product v)
        {
            throw new NotImplementedException();
        }
    }
}