using System.Data.Entity;
using DarzinTest.Models;

namespace DarzinTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DarzinConnectionString")
        {
        }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

	    public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
    }
}