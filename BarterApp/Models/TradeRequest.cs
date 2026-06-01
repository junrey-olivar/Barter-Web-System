using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarterApp.Models
{
    public enum TradeStatus
    {
        Pending,
        Accepted,
        Declined,
        Cancelled,
        Completed
    }

    public class TradeRequest
    {
        public int Id { get; set; }

        [Required]
        public string RequesterId { get; set; } = "";
        [ForeignKey(nameof(RequesterId))]
        public ApplicationUser? Requester { get; set; }

        [Required]
        public int TargetItemId { get; set; }
        [ForeignKey(nameof(TargetItemId))]
        public Item? TargetItem { get; set; }

        public int? OfferedItemId { get; set; }
        [ForeignKey(nameof(OfferedItemId))]
        public Item? OfferedItem { get; set; }

        public TradeStatus Status { get; set; } = TradeStatus.Pending;

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        public string? Notes { get; set; }
    }
}
