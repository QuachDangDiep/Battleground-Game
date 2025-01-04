using battlegameapi.Models;
using Microsoft.EntityFrameworkCore;

namespace battlegameapi.Data
{
    public class BattleGameDbContext : DbContext
    {
        public BattleGameDbContext(DbContextOptions<BattleGameDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<PlayerAsset> PlayerAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key for PlayerAsset
            modelBuilder.Entity<PlayerAsset>()
                .HasKey(pa => new { pa.PlayerId, pa.AssetId });

            // Player relationship
            modelBuilder.Entity<PlayerAsset>()
                .HasOne(pa => pa.Player)
                .WithMany(p => p.PlayerAssets)
                .HasForeignKey(pa => pa.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Asset relationship
            modelBuilder.Entity<PlayerAsset>()
                .HasOne(pa => pa.Asset)
                .WithMany(a => a.PlayerAssets)
                .HasForeignKey(pa => pa.AssetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
