using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinCycleHub.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        // optional walk-in (no customer id)
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        public int? UserId { get; set; }
        public UserProfile? User { get; set; }

        // weight in kilos (if not applicable set to 0 or 1 depending on service)
        [Column(TypeName = "decimal(8,2)")]
        public decimal Weight { get; set; } = 0m;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; } = 0m;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; } = 0m;

        [MaxLength(20)]
        public string PaymentMode { get; set; } = "Cash"; // Cash or GCash

        [MaxLength(200)]
        public string? GCashRef { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? GCashAmount { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Received";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
