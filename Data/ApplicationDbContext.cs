using Microsoft.EntityFrameworkCore;
using SpinCycleHub.Models;

namespace SpinCycleHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<UserProfile> UsersProfile { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set up relationships and defaults if needed
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Service)
                .WithMany()
                .HasForeignKey(t => t.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Transaction)
                .WithMany()
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Rider)
                .WithMany()
                .HasForeignKey(d => d.RiderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
