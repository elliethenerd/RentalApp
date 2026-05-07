using System;
using System.ComponentModel.DataAnnotations;

namespace StarterApp.Database.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        public string Category { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int OwnerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}