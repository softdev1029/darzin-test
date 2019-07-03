using DarzinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DarzinTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DarzinTest.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DarzinTest.Data.ApplicationDbContext";
        }

        protected override void Seed(DarzinTest.Data.ApplicationDbContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new ProductModel { Id = 1, Description = "Bag", Price = 5.5f },
                new ProductModel { Id = 2, Description = "Watch", Price = 6.15f },
                new ProductModel { Id = 3, Description = "Car", Price = 20 },
                new ProductModel { Id = 4, Description = "House", Price = 3.5f }
            );

            context.Customers.AddOrUpdate(x => x.Id,
                new CustomerModel { Id = 1, Name = "Darzin", Description = "Team"},
                new CustomerModel { Id = 2, Name = "Chris", Description = "Dev" }
            );

            var purchases = new List<PurchaseModel>
            {
                new PurchaseModel{Id = 1, CustomerId = 1, ProductId = 1},
                new PurchaseModel{Id = 2, CustomerId = 1, ProductId = 2},
                new PurchaseModel{Id = 3, CustomerId = 2, ProductId = 3},
                new PurchaseModel{Id = 4, CustomerId = 2, ProductId = 4},
                new PurchaseModel{Id = 5, CustomerId = 2, ProductId = 5},
                new PurchaseModel{Id = 6, CustomerId = 2, ProductId = 6},
            };
            purchases.ForEach(s => context.Purchases.Add(s));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
