using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(CreateEvents());
        }

        private List<Event> CreateEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    PerfomanceId = 1,
                    LocationId = 6,
                    PricePerTicket = 12,
                    Date = new DateTime(2022, 12, 13, 19, 00, 00)
                },

                new Event()
                {
                    Id = 2,
                    PerfomanceId = 2,
                    LocationId = 5,
                    PricePerTicket = 14,
                    Date = new DateTime(2022, 11, 24, 22, 30, 00)
                },

                new Event()
                {
                    Id = 3,
                    PerfomanceId = 3,
                    LocationId = 7,
                    PricePerTicket = 12,
                    Date = new DateTime(2022, 11, 22, 14, 00, 00)
                },
                new Event()
                {
                    Id = 4,
                    PerfomanceId = 4,
                    LocationId = 7,
                    PricePerTicket = 25,
                    Date = new DateTime(2022, 12, 23, 19, 00, 00)
                },
                new Event()
                {
                    Id = 5,
                    PerfomanceId = 5,
                    LocationId = 4,
                    PricePerTicket = 40,
                    Date = new DateTime(2022, 12, 18, 20, 00, 00)
                }
            };

            return events;
        }
    }
}
