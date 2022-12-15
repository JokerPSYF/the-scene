using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class rolesA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "7aa3beae-3089-4c75-93df-e242ab89cf7d", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca1ae573-366e-4b52-a076-78c9d1777162", "AQAAAAEAACcQAAAAEGPkeCbzRgLKahillPn7jmmKH39YcRda4KIuPVkkvoQn61YMzlYj2ux3MFY0F5Sgfw==", "5db1805b-f97e-4e8d-96a4-8a9cc78e4c3a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "7361f6f7-fb11-45e9-a59d-05a9b56a15d7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "ccd62d33-055a-494c-b4c4-bb984fca7273" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "7361f6f7-fb11-45e9-a59d-05a9b56a15d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "ccd62d33-055a-494c-b4c4-bb984fca7273" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b97379a1-4a4b-4cdb-b57f-edf338d73730");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb190f5-75cc-4d50-9308-a733ec203f4b", "AQAAAAEAACcQAAAAEJiZZcCk+n56xmE4LSG/1xtJwLa9wNAiHhAmhM0jr3UUjiJ6IJBDSPypqCVssoY5EQ==", "e810efe8-7d55-4a73-bd10-33a77697a34f" });
        }
    }
}
