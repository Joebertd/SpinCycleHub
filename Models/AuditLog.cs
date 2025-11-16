using System;

namespace SpinCycleHub.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string ActionText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
