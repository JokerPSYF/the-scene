using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedPerfomanceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851");

            migrationBuilder.InsertData(
                table: "PerfomanceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Movie" },
                    { 2, "Theatrical play" },
                    { 3, "Opera" },
                    { 4, "Ballet" },
                    { 5, "Concert" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfomanceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerfomanceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PerfomanceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PerfomanceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PerfomanceTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a15400e-4991-4d66-87df-05a82c3bf851", 0, "c796ef5c-e527-4cbf-815c-e5a4e866bf9d", "TODOR@MAIL.COM", false, false, null, "todor@mail.com", "Todor", "AQAAAAEAACcQAAAAEBJtkEV+KBDVzLtRfzqqJbY6CQeWqRanAK7eCQqr3jexRGk6ztjWeq/4PuZiog+hng==", null, false, "971d7817-235b-49be-8588-87a531f486e0", false, "TODOR" });
        }
    }
}
