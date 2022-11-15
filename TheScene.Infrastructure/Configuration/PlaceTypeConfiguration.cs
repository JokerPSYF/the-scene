using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class PlaceTypeConfiguration : IEntityTypeConfiguration<PlaceType>
    {
        public void Configure(EntityTypeBuilder<PlaceType> builder)
        {
            builder.HasData(CreatePlaceType());
        }

        private List<PlaceType> CreatePlaceType()
        {
            var placeTypes = new List<PlaceType>()
            {
                new PlaceType()
                {
                    Id = 1,
                    Name = "Cinema"
                },

                new PlaceType()
                {
                    Id = 2,
                    Name = "Theater"
                },

                new PlaceType()
                {
                    Id = 3,
                    Name = "Open air theater"
                },

                new PlaceType()
                {
                    Id = 4,
                    Name = "Stadium"
                }
            }; 

            return placeTypes;
        }
    }
}
