using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarterApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string OwnerId { get; set; } = "";
        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser? Owner { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
