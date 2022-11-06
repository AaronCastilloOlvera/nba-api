using Microsoft.EntityFrameworkCore;
using nba_api.Models;

namespace nba_api
{
    public class NBAContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public NBAContext(DbContextOptions<NBAContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(t =>
            {
                t.ToTable("Team");

                t.Property( t => t.TeamId).ValueGeneratedNever();

                t.Property( t => t.Name).IsRequired(false);

                t.Property(t => t.ShortName).IsRequired(false);

                t.Property(t => t.UrlLogo).IsRequired(false);

                t.Property(t => t.Divition).IsRequired(false);

                t.Property(t => t.Location).IsRequired(false);

               t.Property(t => t.PrincipalColor).IsRequired(false);

            });
        }

    }
}
