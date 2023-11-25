using Microsoft.EntityFrameworkCore;
using PRODUCT_CRUD.Contracts.DBModel;

namespace PRODUCT_CRUD.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Employee Table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                Name = "Samsung SmartPhone",
                Description = "Samsung SmartPhone 2023",
                Price = 400
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 2,
                Name = "Dell Laptop",
                Description = "Dell Laptop 2023",
                Price = 500
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 3,
                Name = "Iphone Smartwatch",
                Description = "Iphone Smartwatch 2023",
                Price = 5000
            });
        }
    }
}
