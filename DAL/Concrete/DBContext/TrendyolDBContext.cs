using Models.Entities;
using Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.DBContext
{
    public class TrendyolDBContext : DbContext
    {
        public TrendyolDBContext() : base("Server=.;Database=TrendyolDB;Integrated Security=true")
        {
            Database.SetInitializer(new DataBaseDataCreater());


        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductsMapping());
            modelBuilder.Configurations.Add(new CategoriesMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderDetailsMapping());
            modelBuilder.Configurations.Add(new CustomersMapping());
            modelBuilder.Configurations.Add(new StoreMapping());
        }
    }

    public class DataBaseDataCreater : CreateDatabaseIfNotExists<TrendyolDBContext>
    {
        protected override void Seed(TrendyolDBContext context)
        {
            Categories categories1 = new Categories();
            categories1.CategoryName = "Giyim";
            context.Categories.Add(categories1);

            Categories categories2 = new Categories();
            categories2.CategoryName = "Elektronik";
            context.Categories.Add(categories2);

            Categories categories3 = new Categories();
            categories3.CategoryName = "Beyaz eşya";
            context.Categories.Add(categories3);

            Categories categories4 = new Categories();
            categories4.CategoryName = "Spor";
            context.Categories.Add(categories4);

            Categories categories5 = new Categories();
            categories5.CategoryName = "Mutfak";
            context.Categories.Add(categories5);

            Products products1 = new Products();
            products1.CategoryID = 1;
            products1.ProductName = "Gömlek";
            products1.UnitPrice = 50;
            products1.UnitInStock = 40;
            products1.IsActive = true;
            context.Products.Add(products1);

            Products products2 = new Products();
            products2.CategoryID = 1;
            products2.ProductName = "Tşört";
            products2.UnitPrice = 30;
            products2.UnitInStock = 65;
            products2.IsActive = true;
            context.Products.Add(products2);

            Products products3 = new Products();
            products3.CategoryID = 1;
            products3.ProductName = "Pantolon";
            products3.UnitPrice = 80;
            products3.UnitInStock = 45;
            products3.IsActive = true;
            context.Products.Add(products3);

            Products products4 = new Products();
            products4.CategoryID = 1;
            products4.ProductName = "Ceket";
            products4.UnitPrice = 180;
            products4.UnitInStock = 35;
            products4.IsActive = true;
            context.Products.Add(products4);

            Products products5 = new Products();
            products5.CategoryID = 1;
            products5.ProductName = "Ayakkabı";
            products5.UnitPrice = 150;
            products5.UnitInStock = 60;
            products5.IsActive = true;
            context.Products.Add(products5);

            Products products6 = new Products();
            products6.CategoryID = 2;
            products6.ProductName = "Telefon";
            products6.UnitPrice = 1300;
            products6.UnitInStock = 70;
            products6.IsActive = true;
            context.Products.Add(products6);

            Products products7 = new Products();
            products7.CategoryID = 2;
            products7.ProductName = "Laptop";
            products7.UnitPrice = 2500;
            products7.UnitInStock = 20;
            products7.IsActive = true;
            context.Products.Add(products7);

            Products products8 = new Products();
            products8.CategoryID = 2;
            products8.ProductName = "Tablet";
            products8.UnitPrice = 800;
            products8.UnitInStock = 50;
            products8.IsActive = true;
            context.Products.Add(products8);

            Products products9 = new Products();
            products5.CategoryID = 2;
            products5.ProductName = "Akıllı saat";
            products5.UnitPrice = 450;
            products5.UnitInStock = 25;
            products5.IsActive = true;
            context.Products.Add(products5);

            Products products10 = new Products();
            products10.CategoryID = 2;
            products10.ProductName = "Şarj cihazı";
            products10.UnitPrice = 85;
            products10.UnitInStock = 70;
            products10.IsActive = true;
            context.Products.Add(products10);

            Products products11 = new Products();
            products11.CategoryID = 3;
            products11.ProductName = "Buzdolabı";
            products11.UnitPrice = 1800;
            products11.UnitInStock = 20;
            products11.IsActive = true;
            context.Products.Add(products11);

            Products products12 = new Products();
            products12.CategoryID = 3;
            products12.ProductName = "Çamaşır makinesi";
            products12.UnitPrice = 1400;
            products12.UnitInStock = 15;
            products12.IsActive = true;
            context.Products.Add(products12);

            Products products13 = new Products();
            products13.CategoryID = 3;
            products13.ProductName = "Fırın";
            products13.UnitPrice = 1200;
            products13.UnitInStock = 25;
            products13.IsActive = true;
            context.Products.Add(products13);

            Products products14 = new Products();
            products14.CategoryID = 4;
            products14.ProductName = "Dumbell";
            products14.UnitPrice = 50;
            products14.UnitInStock = 35;
            products14.IsActive = true;
            context.Products.Add(products14);

            Products products15 = new Products();
            products15.CategoryID = 4;
            products15.ProductName = "Plaka ağırlık";
            products15.UnitPrice = 100;
            products15.UnitInStock = 100;
            products15.IsActive = true;
            context.Products.Add(products15);

            Products products16 = new Products();
            products16.CategoryID = 4;
            products16.ProductName = "Bench sehbası";
            products16.UnitPrice = 350;
            products16.UnitInStock = 15;
            products16.IsActive = true;
            context.Products.Add(products16);

            Products products17 = new Products();
            products17.CategoryID = 5;
            products17.ProductName = "Tabak";
            products17.UnitPrice = 10;
            products17.UnitInStock = 150;
            products17.IsActive = true;
            context.Products.Add(products17);

            Products products18 = new Products();
            products18.CategoryID = 5;
            products18.ProductName = "Kaşık";
            products18.UnitPrice = 2;
            products18.UnitInStock = 500;
            products18.IsActive = true;
            context.Products.Add(products18);

            Products products19 = new Products();
            products19.CategoryID = 5;
            products19.ProductName = "Çatal";
            products19.UnitPrice = 2;
            products19.UnitInStock =500;
            products19.IsActive = true;
            context.Products.Add(products19);

            context.SaveChanges();
        }
    }
        
}
