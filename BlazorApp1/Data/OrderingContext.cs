using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Alice Johnson", Email = "alice@example.com" },
                new Customer { Id = 2, Name = "Bob Smith", Email = "bob@example.com" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, Stock = 10 },
                new Product { Id = 2, Name = "Mouse", Price = 29.99m, Stock = 50 },
                new Product { Id = 3, Name = "Keyboard", Price = 79.99m, Stock = 30 }
            );
        }
    }
}
