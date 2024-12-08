using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Date
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}