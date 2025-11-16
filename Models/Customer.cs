using System;
using System.ComponentModel.DataAnnotations;

namespace SpinCycleHub.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Contact { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
