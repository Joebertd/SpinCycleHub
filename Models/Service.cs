using System.ComponentModel.DataAnnotations;

namespace SpinCycleHub.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string ServiceName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0m;
    }
}
