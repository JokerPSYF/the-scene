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
                    UserId = "7a15400e-4991-4d66-87df-05a82c3bf851"
                }
            };
        }
    }
}
