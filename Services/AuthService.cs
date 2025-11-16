using Microsoft.EntityFrameworkCore;
using SpinCycleHub.Data;
using SpinCycleHub.Models;

namespace SpinCycleHub.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _db;

        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UserProfile?> LoginAsync(string username, string password)
        {
            return await _db.UsersProfile
                .FirstOrDefaultAsync(u =>
                    u.Username == username &&
                    u.PasswordHash == password);
        }

        public bool IsOwner(UserProfile user) => user.Role == UserRole.Owner;
        public bool IsSupervisor(UserProfile user) => user.Role == UserRole.Supervisor;
    }
}

