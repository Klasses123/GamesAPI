using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI
{
    public class DbMainContext : DbContext
    {
        public DbMainContext(DbContextOptions<DbMainContext> options) : base(options)
        {
            Database.AutoTransactionsEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>();
            modelBuilder.Entity<Genre>();
            modelBuilder.Entity<DeveloperStudio>();
            modelBuilder.Entity<VideoGameGenre>().HasOne(x => x.Genre).WithMany(x => x.Genres).HasForeignKey(x => x.GenreId);
            modelBuilder.Entity<VideoGameGenre>().HasOne(x => x.Game).WithMany(x => x.Genres).HasForeignKey(x => x.GameId);

            var seedData = new SeedData();
            seedData.SetSeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
