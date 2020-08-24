using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataApp.Models
{
    public static class DataSeed
    {
        private static Product[] Products
        {
            get
            {
                var products = new Product[]
                {
                    new Product { Name = "Kayak", Category = "Watersports", Price = 275, Color = Color.Green, InStock = true } ,
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95m, Color = Color.Red, InStock = true },
                    new Product { Name = "Soccer Ball", Category = "Soccer", Price = 19.50m, Color = Color.Blue, InStock = true },
                    new Product { Name = "Corner Flags", Category = "Soccer", Price = 34.95m, Color = Color.Green, InStock = true },
                    new Product { Name = "Stadium", Category = "Soccer", Price = 79500, Color = Color.Red, InStock = true },
                    new Product { Name = "Thinking Сар", Category = "Chess", Price = 16, Color = Color.Blue, InStock = true },
                    new Product { Name = "Unsteady Chair", Category = "Chess", Price = 29.95m, Color = Color.Green, InStock = true },
                    new Product { Name = "Human Chess Board", Category = "Chess", Price = 75, Color = Color.Red, InStock = true },
                    new Product { Name = "Bling-Bling King", Category = "Chess", Price = 1200, Color = Color.Blue, InStock = true }
                };

                Supplier sl = new Supplier
                {
                    Name = "Surf Dudes",
                    City = "San Jose",
                    State = "СА"
                };

                Supplier s2 = new Supplier
                {
                    Name = "Chess Kings",
                    City = "Seattle",
                    State = "WA"
                };

                products.First().Supplier = sl;
                foreach (Product р in products.Where(р => р.Category == "Chess"))
                    р.Supplier = s2;

                return products;
            }
        }

        private static Customer[] Customers =
        {
            new Customer { Name = "Alice Smith", City = "New York", Country = "USA" } ,
            new Customer { Name = "ВоЬ Jones", City = "Paris", Country = "France" },
            new Customer { Name = "Charlie Davies", City = "London", Country = "UK" }
        };

        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is DataContext productContext && productContext.Products.Count() == 0)
                {
                    productContext.Products.AddRange(Products);
                }
                else if (context is CustomerContext customerContext && customerContext.Customers.Count() == 0)
                {
                    customerContext.Customers.AddRange(Customers);
                }

                context.SaveChanges();
            }
        }
    }
}
