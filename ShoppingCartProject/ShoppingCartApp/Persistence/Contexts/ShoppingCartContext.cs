using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Persistence.Contexts
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed for ProductCategory table.
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                Name = "Cars"
            }, new ProductCategory
            {
                Id = 2,
                Name = "Planes"
            }, new ProductCategory
            {
                Id = 3,
                Name = "Trucks"
            }, new ProductCategory
            {
                Id = 4,
                Name = "Boats"
            }, new ProductCategory
            {
                Id = 5,
                Name = "Rockets"
            });

            //Seed for Product table.
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ProductCategoryId = 1,
                Name = "Ferari",
                Price = 3000
            }, new Product
            {
                Id = 2,
                ProductCategoryId = 1,
                Name = "Benz",
                Price = 4000
            }, new Product
            {
                Id = 3,
                ProductCategoryId = 2,
                Name = "AirBus",
                Price = 5000
            }, new Product
            {
                Id = 4,
                ProductCategoryId = 2,
                Name = "Jet",
                Price = 6000
            }, new Product
            {
                Id = 5,
                ProductCategoryId = 3,
                Name = "Hummer",
                Price = 7000
            }, new Product
            {
                Id = 6,
                ProductCategoryId = 3,
                Name = "Container",
                Price = 8000
            }, new Product
            {
                Id = 7,
                ProductCategoryId = 4,
                Name = "Spider",
                Price = 9000
            }, new Product
            {
                Id = 8,
                ProductCategoryId = 4,
                Name = "Jet Boat",
                Price = 10000
            }, new Product
            {
                Id = 9,
                ProductCategoryId = 5,
                Name = "RocketA",
                Price = 11000
            }, new Product
            {
                Id = 10,
                ProductCategoryId = 5,
                Name = "RocketB",
                Price = 12000
            }
            );
        }
    }
}
