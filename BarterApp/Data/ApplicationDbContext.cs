using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarterApp.Models;


namespace BarterApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<TradeRequest> TradeRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Prevent deletion conflicts
            builder.Entity<TradeRequest>()
                .HasOne(tr => tr.TargetItem)
                .WithMany()
                .HasForeignKey(tr => tr.TargetItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TradeRequest>()
                .HasOne(tr => tr.OfferedItem)
                .WithMany()
                .HasForeignKey(tr => tr.OfferedItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
