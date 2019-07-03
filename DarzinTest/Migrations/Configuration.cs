using DarzinTest.Models;

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

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
