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
                    Seats = 400,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d505.2189479926242!2d27.46955384608908!3d42.498052194717765!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694be410c32c9%3A0x1887194803bffd9f!2z0JrRg9C70YLRg9GA0LXQvSDQtNC-0Lwg0J3QpdCa!5e0!3m2!1sen!2sbg!4v1671710527425!5m2!1sen!2sbg"
                },

                new Location()
                {
                    Id = 2,
                    Name = "Military Hotel",
                    Address = "48 улица „Христо Ботев“, 8000 Burgas",
                    PlaceTypeId = 2,
                    Seats = 300,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1485726.0365802157!2d25.608665091216206!3d43.33919270804973!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694bee7bc0013%3A0x64d7652ab70a143!2sMilitary%20Hotel!5e0!3m2!1sen!2sbg!4v1671710657625!5m2!1sen!2sbg"
                },

                new Location()
                {
                    Id = 3,
                    Name = "Drama Theatre Adriana Budevska",
                    Address = "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 320,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.9731228793357!2d27.46557931575126!3d42.49212403474332!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b87b8e8175%3A0x162a847dd72fc4be!2sDrama%20Theatre%20Adriana%20Budevska!5e0!3m2!1sen!2sbg!4v1671711023393!5m2!1sen!2sbg"
                },
                new Location()
                {
                    Id = 4,
                    Name = "Open-air theater",
                    Address = "Demokratsia Blvd 94, 8001 Burgas Center, Burgas",
                    PlaceTypeId = 3,
                    Seats = 1970,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.767603047012!2d27.473731165751342!3d42.49649308446668!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694ea2b320899%3A0xd212510bf1f13ad2!2sOpen-air%20theater!5e0!3m2!1sen!2sbg!4v1671711176033!5m2!1sen!2sbg"
                },
                new Location()
                {
                    Id = 5,
                    Name = "Cinema City",
                    Address = "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas",
                    PlaceTypeId = 1,
                    Seats = 153,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.0000352977227!2d27.452702515751575!3d42.51280723343363!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a693634968f40b%3A0x33fae8c02fef63e6!2sCinema%20City!5e0!3m2!1sen!2sbg!4v1671711225819!5m2!1sen!2sbg"
                },
                new Location()
                {
                    Id = 6,
                    Name = "Държавен куклен театър",
                    Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 200,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23527.987394558437!2d27.43738163133954!3d42.51284146838338!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a69536d031a19f%3A0xee7a2bf8742be5d!2z0JTRitGA0LbQsNCy0LXQvSDQutGD0LrQu9C10L0g0YLQtdCw0YLRitGA!5e0!3m2!1sen!2sbg!4v1671711273085!5m2!1sen!2sbg"
                },
                new Location()
                {
                    Id = 7,
                    Name = "The Opera House",
                    Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                    PlaceTypeId = 2,
                    Seats = 300,
                    Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.8628304682!2d27.4671644157514!3d42.494468734594896!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b8b420f267%3A0x2bed66575402c90b!2sThe%20Opera%20House!5e0!3m2!1sen!2sbg!4v1671711341381!5m2!1sen!2sbg"
                }
            };

            return locations;
        }
    }
}
