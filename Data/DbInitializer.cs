using Microsoft.EntityFrameworkCore;
using SpinCycleHub.Models;

namespace SpinCycleHub.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationDbContext db, ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            try
            {
                // Apply migrations (if any). This will create DB objects when migrations exist.
                await _db.Database.MigrateAsync();

                // Seed Services
                if (!await _db.Services.AnyAsync())
                {
                    var services = new[]
                    {
                        new Service { ServiceName = "Full Drop-off", Description = "Wash, dry, fold - up to 50 kg", Price = 180m },
                        new Service { ServiceName = "Self Wash", Description = "Self-service wash per load", Price = 50m },
                        new Service { ServiceName = "Dry", Description = "Drying per load", Price = 55m },
                        new Service { ServiceName = "Fold", Description = "Folding per load", Price = 30m }
                    };
                    await _db.Services.AddRangeAsync(services);
                }

                // Seed Users (Owner and Supervisor)
                if (!await _db.UsersProfile.AnyAsync(u => u.Username == "owner"))
                {
                    _db.UsersProfile.Add(new UserProfile
                    {
                        Username = "owner",
                        PasswordHash = "Owner@123", // demo-only plaintext
                        FullName = "Owner Admin",
                        Role = UserRole.Owner
                    });
                }
                if (!await _db.UsersProfile.AnyAsync(u => u.Username == "supervisor"))
                {
                    _db.UsersProfile.Add(new UserProfile
                    {
                        Username = "supervisor",
                        PasswordHash = "Super@123",
                        FullName = "Supervisor",
                        Role = UserRole.Supervisor
                    });
                }

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred seeding the DB.");
                throw;
            }
        }
    }
}
