using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinCycleHub.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Category { get; set; } = string.Empty;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
