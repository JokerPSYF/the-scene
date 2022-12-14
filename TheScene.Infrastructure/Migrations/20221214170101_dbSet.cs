using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class dbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "The first name of the user");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "The first name of the user");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a15400e-4991-4d66-87df-05a82c3bf851", 0, "95d3d71e-8a1d-4cc6-97bf-26d9fc3d2f72", "IdentityUser", "TODOR@MAIL.COM", false, false, null, "todor@mail.com", "Todor", "AQAAAAEAACcQAAAAEP2LO8uXVuQ+53nJSvqC4PTIWXtRdnzxh2sWVQTWt/rW76vva/Ns03Kn2AdWu/3h9g==", null, false, "66326c05-cdc0-426c-9205-b15541fc8d37", false, "TODOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9878d3-f564-4c59-a4a5-dcef8f79d147", "AQAAAAEAACcQAAAAEHgzSuHy1kyv1XKeX2KW0DcrYS82eAXSO1maeDDdxNyQCs6FUOYHFstQ2CkplQapBw==", "f1e0f2fe-78d9-440d-8103-5f3406450844" });
        }
    }
}
