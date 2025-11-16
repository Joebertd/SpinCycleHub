using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinCycleHub.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public int TransactionId { get; set; }
        public Transaction? Transaction { get; set; }

        public int? RiderId { get; set; }
        public UserProfile? Rider { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryFee { get; set; } = 0m;

        public string Status { get; set; } = "Pending";

        // stored filename of proof (optional)
        public string? ProofFile { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
