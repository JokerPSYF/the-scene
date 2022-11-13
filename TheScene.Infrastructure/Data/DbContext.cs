using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Data
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Perfomance> Perfomances { get; set; } = null!;

        public DbSet<PerfomanceType> PerfomanceTypes { get; set; } = null!;

        public DbSet<PlaceType> PlaceTypes { get; set; } = null!;
    }
}