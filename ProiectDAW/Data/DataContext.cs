using ProiectDAW.Models;

namespace ProiectDAW.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<OrderVideoGame> OrderVideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Publisher>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<VideoGame>()
                .HasIndex(vg => vg.Title)
                .IsUnique();

            modelBuilder.Entity<OrderVideoGame>()
                .HasKey(ovg => new { ovg.OrderId, ovg.VideoGameId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
