using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            throw new NotImplementedException();
        }

        private List<Event> CreateEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {

                }
            };

            return null;
        }
    }
}
