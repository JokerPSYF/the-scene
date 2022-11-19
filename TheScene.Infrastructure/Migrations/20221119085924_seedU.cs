using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a15400e-4991-4d66-87df-05a82c3bf851", 0, "de87f56a-2bfa-4009-bce8-f23d39cf65f1", "TODOR@MAIL.COM", false, false, null, "todor@mail.com", "Todor", "AQAAAAEAACcQAAAAELycZ6zquqkaZZOyPzkdT/1WxL39OaGUDmLXmaHJshBazN0TWk7rEPkvPKOkT/hIsw==", null, false, "c20713e0-471a-4826-9eb0-12fd1a2b6f22", false, "TODOR" });
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
