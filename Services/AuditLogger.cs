using SpinCycleHub.Data;
using SpinCycleHub.Models;

namespace SpinCycleHub.Helpers
{
    public class AuditLogger
    {
        private readonly ApplicationDbContext _db;

        public AuditLogger(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task LogAsync(int? userId, string action)
        {
            _db.AuditLogs.Add(new AuditLog
            {
                UserId = userId,
                ActionText = action,
                CreatedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
        }
    }
}
