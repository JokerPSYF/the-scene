using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class PerfomanceTypeConfiguration : IEntityTypeConfiguration<PerfomanceType>
    {
        public void Configure(EntityTypeBuilder<PerfomanceType> builder)
        {
            builder.HasData(CreatePerfomanceTypes());
        }

        private List<PerfomanceType> CreatePerfomanceTypes()
        {
            var types = new List<PerfomanceType>() 
            {
                new PerfomanceType()
                {
                    Id = 1,
                    Name = "Movie"
                },

                new PerfomanceType()
                {
                    Id = 2,
                    Name = "Theatrical play"
                },

                new PerfomanceType()
                {
                    Id = 3,
                    Name = "Opera"
                },

                new PerfomanceType()
                {
                    Id = 4,
                    Name = "Ballet"
                },

                new PerfomanceType()
                {
                    Id = 5,
                    Name = "Concert"
                }
            };

            return types;
        }
    }
}
