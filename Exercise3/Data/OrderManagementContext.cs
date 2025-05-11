using Exercise3.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercise3.Pages.Data
{
    public class OrderManagementContext : DbContext
    {
        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly map entities to their database table names
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Agent>().ToTable("Agent");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");

            // Configure relationships
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Item)
                .WithMany()
                .HasForeignKey(od => od.ItemID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Agent)
                .WithMany()
                .HasForeignKey(o => o.AgentID);
        }
    }
}

