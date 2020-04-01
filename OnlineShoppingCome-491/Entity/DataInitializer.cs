using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShoppingCome_491.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)

        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Dress", Description="Dress product"},
                new Category(){Name="Sweater", Description="Sweater product"},
                new Category(){Name="Blouse", Description="Blouse product"},
            };
            foreach(var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product(){Name="Dress1", Description="...", Price=99.00 ,Stock=100, IsApproved=true, CategoryId=1, IsHome=true , Image="1.jpg"},
                new Product(){Name="Sweater1", Description="...", Price=55.00 ,Stock=100, IsApproved=false, CategoryId=2, IsHome=true,  Image="2.jpg"},
                new Product(){Name="Blouse1", Description="...", Price=99.00 ,Stock=50, IsApproved=false, CategoryId=3,IsHome=true, Image="3.jpg"},
                new Product(){Name="Blouse2", Description="...", Price=50.00 ,Stock=50, IsApproved=true, CategoryId=3, IsHome=true,Image="4.jpg"},
                new Product(){Name="Sweater2", Description="...", Price=79.00 ,Stock=100, IsApproved=true, CategoryId=2, IsHome=true,Image="5.jpg"},
                new Product(){Name="Dress2", Description="...", Price=69.00 ,Stock=100, IsApproved=true, CategoryId=1, IsHome=true,Image="6.jpg"},
                 new Product(){Name="Sweater3", Description="...", Price=15.00 ,Stock=100, IsApproved=true, CategoryId=2, IsHome=true,Image="7.jpg"}
            };
            foreach(var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}