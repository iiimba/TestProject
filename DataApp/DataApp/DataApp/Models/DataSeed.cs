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

                ContactLocation hq = new ContactLocation
                {
                    LocationName = "Corporate HQ",
                    Address = "200 Acme Way"
                };
                ContactDetails ЬоЬ = new ContactDetails
                {
                    Name = "Bob Smith",
                    Phone = "555-107-1234",
                    Location = hq
                };
                Supplier acme = new Supplier
                {
                    Name = "Acme Со",
                    City = "New York",
                    State = "NY",
                    Contact = ЬоЬ
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

                foreach (var p in products)
                {
                    if (p == products[0])
                    {
                        p.Supplier = sl;
                    }
                    else if (p.Category == "Chess")
                    {
                        p.Supplier = s2;
                    }
                    else
                    {
                        p.Supplier = acme;
                    }
                }

                return products;
            }
        }

        private static Customer[] Customers =
        {
            new Customer { Name = "Alice Smith", City = "New York", Country = "USA" } ,
            new Customer { Name = "ВоЬ Jones", City = "Paris", Country = "France" },
            new Customer { Name = "Charlie Davies", City = "London", Country = "UK" }
        };

        public static Shipment[] Shipments
        {
            get
            {
                return new Shipment[]
                {
                    new Shipment { ShipperName = "Express Со", StartCity = "New York", EndCity = "San Jose" },
                    new Shipment { ShipperName = "Tortoise Shipping", StartCity = "Boston", EndCity = "Chicago" },
                    new Shipment { ShipperName = "Air Express", StartCity = "Мiami", EndCity = "Seattle" }
                };
            }
        }

        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is DataContext productContext && productContext.Products.Count() == 0)
                {
                    productContext.Products.AddRange(Products);
                    productContext.Set<Shipment>().AddRange(Shipments);
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
