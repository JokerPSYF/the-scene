using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheScene.Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(CreateUserRoles());
        }

        private List<IdentityUserRole<string>> CreateUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                RoleId = "b97379a1-4a4b-4cdb-b57f-edf338d73730",
                UserId = "7361f6f7-fb11-45e9-a59d-05a9b56a15d7"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "b97379a1-4a4b-4cdb-b57f-edf338d73730",
                    UserId = "ccd62d33-055a-494c-b4c4-bb984fca7273"
                }
            };
        }
    }
}
