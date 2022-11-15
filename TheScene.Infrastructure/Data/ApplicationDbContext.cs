using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheScene.Infrastructure.Configuration;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PerfomanceTypeConfiguration());
            builder.ApplyConfiguration(new PlaceTypeConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Perfomance> Perfomances { get; set; } = null!;

        public DbSet<PerfomanceType> PerfomanceTypes { get; set; } = null!;

        public DbSet<PlaceType> PlaceTypes { get; set; } = null!;
    }
}