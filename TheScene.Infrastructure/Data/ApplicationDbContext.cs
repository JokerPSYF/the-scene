using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new PerfomanceTypeConfiguration());
            builder.ApplyConfiguration(new PlaceTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new PerfomanceConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Perfomance> Perfomances { get; set; } = null!;

        public DbSet<PerfomanceType> PerfomanceTypes { get; set; } = null!;

        public DbSet<PlaceType> PlaceTypes { get; set; } = null!;
    }
}