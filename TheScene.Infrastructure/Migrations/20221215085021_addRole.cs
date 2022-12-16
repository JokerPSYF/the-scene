using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class addRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb190f5-75cc-4d50-9308-a733ec203f4b", "AQAAAAEAACcQAAAAEJiZZcCk+n56xmE4LSG/1xtJwLa9wNAiHhAmhM0jr3UUjiJ6IJBDSPypqCVssoY5EQ==", "e810efe8-7d55-4a73-bd10-33a77697a34f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4ffe764-ac41-4913-8712-2626c407dfb8", "AQAAAAEAACcQAAAAEDH7/Gra/N2v61KyBMaFtR+buomdhTMPL13vLH0fqhM9tNYTb4rCvkzOICtowMu14Q==", "da3d4145-38ce-4360-b81c-d3a6adde1798" });
        }
    }
}
