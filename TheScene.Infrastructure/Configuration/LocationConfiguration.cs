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
                    Name = "Културен дом НХК",
                    Address = "pl. \"Troykata\" 1, 8000 Burgas Center, Burgas",
                    PlaceTypeId = 2,
                    Seats = 400
                },

                new Location()
                {
                    Id = 2,
                    Name = "Military Hotel",
                    Address = "48 улица „Христо Ботев“, 8000 Burgas",
                    PlaceTypeId = 2,
                    Seats = 300               
                },

                new Location()
                {
                    Id = 3,
                    Name = "Drama Theatre Adriana Budevska",
                    Address = "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 320
                },
                new Location()
                {
                    Id = 4,
                    Name = "Open-air theater",
                    Address = "Demokratsia Blvd 94, 8001 Burgas Center, Burgas",
                    PlaceTypeId = 3,
                    Seats = 1970
                },
                new Location()
                {
                    Id = 5,
                    Name = "Cinema City",
                    Address = "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas",
                    PlaceTypeId = 1,
                    Seats = 153
                },
                new Location()
                {
                    Id = 6,
                    Name = "Държавен куклен театър",
                    Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 200
                },
                new Location()
                {
                    Id = 7,
                    Name = "The Opera House",
                    Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 300
                }
            };

            return locations;
        }
    }
}
