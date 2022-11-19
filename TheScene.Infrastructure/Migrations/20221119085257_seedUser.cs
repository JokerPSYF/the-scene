using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a15400e-4991-4d66-87df-05a82c3bf851", 0, "c796ef5c-e527-4cbf-815c-e5a4e866bf9d", "TODOR@MAIL.COM", false, false, null, "todor@mail.com", "Todor", "AQAAAAEAACcQAAAAEBJtkEV+KBDVzLtRfzqqJbY6CQeWqRanAK7eCQqr3jexRGk6ztjWeq/4PuZiog+hng==", null, false, "971d7817-235b-49be-8588-87a531f486e0", false, "TODOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851");
        }
    }
}
