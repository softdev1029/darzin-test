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
    }
}