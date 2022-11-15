using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(CreateGenres());
        }

        private List<Genre> CreateGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Action"
                },

                new Genre()
                {
                    Id = 2,
                    Name = "Comedy"
                },

                new Genre()
                {
                    Id = 3,
                    Name = "Drama"
                },

                new Genre()
                {
                    Id = 4,
                    Name = "Fantasy"
                },

                new Genre()
                {
                    Id = 5,
                    Name = "Horror"
                },

                new Genre()
                {
                    Id = 6,
                    Name = "Mystery"
                },

                new Genre()
                {
                    Id = 7,
                    Name = "Romance"
                },

                new Genre()
                {
                    Id = 8,
                    Name = "Thriller"
                },

                new Genre()
                {
                    Id = 9,
                    Name = "Western"
                },

                new Genre()
                {
                    Id = 10,
                    Name = "Pop music"
                },

                new Genre()
                {
                    Id = 11,
                    Name = "Hip hop music"
                },

                new Genre()
                {
                    Id = 12,
                    Name = "Rock music"
                },

                new Genre()
                {
                    Id = 13,
                    Name = "Folk music"
                },

                new Genre()
                {
                    Id = 14,
                    Name = "Pop Folk music"
                },

                new Genre()
                {
                    Id = 15,
                    Name = "Jazz music"
                },

                new Genre()
                {
                    Id = 16,
                    Name = "Electronic music"
                },

                new Genre()
                {
                    Id = 17,
                    Name = "Classical music"
                },

                new Genre()
                {
                    Id = 18,
                    Name = "Christian music"
                },
            };

            return genres;
        }
    }
}