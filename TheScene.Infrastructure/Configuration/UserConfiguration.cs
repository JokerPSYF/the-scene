using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheScene.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<IdentityUser> CreateUsers()
        {
            var users = new List<IdentityUser>();

            var hasher = new PasswordHasher<IdentityUser>();


            var admin = new IdentityUser()
            {
                Id = "7a15400e-4991-4d66-87df-05a82c3bf851",
                UserName = "TODOR",
                NormalizedUserName = "Todor",
                Email = "TODOR@MAIL.COM",
                NormalizedEmail = "todor@mail.com"
            };

            admin.PasswordHash = hasher.HashPassword(admin, "todor123");

            users.Add(admin);

            return users;
        }
    }
}
