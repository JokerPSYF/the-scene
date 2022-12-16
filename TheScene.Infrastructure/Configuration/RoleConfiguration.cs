using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheScene.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "b97379a1-4a4b-4cdb-b57f-edf338d73730",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };
        }
    }
}
