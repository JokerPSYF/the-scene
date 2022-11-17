using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
        }

        private List<Location> CreateLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                {
                    Id = 1,
                    Address = "pl. \"Troykata\" 1, 8000 Burgas Center, Burgas",
                    PlaceTypeId = 2,
                },

                new Location()
                {
                    Id = 2,
                    Address = "48 улица „Христо Ботев“, 8000 Бургас",
                    PlaceTypeId = 2,
                },

                new Location()
                {
                    Id = 3,
                    Address = "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas",
                    PlaceTypeId = 2,
                },
                new Location()
                {
                    Id = 4,
                    Address = "Demokratsia Blvd 94, 8001 Burgas Center, Burgas",
                    PlaceTypeId = 3,
                },
                new Location()
                {
                    Id = 5,
                    Address = "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas",
                    PlaceTypeId = 1,
                },
            };

            return locations;
        }
    }
}
