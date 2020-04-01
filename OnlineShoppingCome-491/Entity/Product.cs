using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineShoppingCome_491.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public String Name { get; set; }
        [DisplayName("Product Description")]
        public String Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }//her bir ürünün kategorisi var anlamında yabancıl anahtar kategori de bir ıd ye karsılık gelir
        public Category Category { get; set; }

    }
}