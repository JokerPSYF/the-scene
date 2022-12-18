using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data;

namespace TheScene.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<AppUser> CreateUsers()
        {
            var users = new List<AppUser>();

            var hasher = new PasswordHasher<AppUser>();


            var admin = new AppUser()
            {
                Id = "7a15400e-4991-4d66-87df-05a82c3bf851",
                UserName = "Teo",
                FirstName = "Todor",
                LastName = "Vasilev",
                NormalizedUserName = "TEO",
                Email = "teo@mail.com",
                NormalizedEmail = "TEO@MAIL.COM"
            };

            admin.PasswordHash = hasher.HashPassword(admin, "todor123");

            users.Add(admin);

            return users;
        }
    }
}
