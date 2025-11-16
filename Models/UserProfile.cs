using System;
using System.ComponentModel.DataAnnotations;

namespace SpinCycleHub.Models
{
    public enum UserRole
    {
        Owner,
        Supervisor,
        Rider
    }

    public class UserProfile
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        // DEMO: plaintext password for seeding - replace with hashed password for production
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Supervisor;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
