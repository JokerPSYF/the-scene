using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4ffe764-ac41-4913-8712-2626c407dfb8", "AQAAAAEAACcQAAAAEDH7/Gra/N2v61KyBMaFtR+buomdhTMPL13vLH0fqhM9tNYTb4rCvkzOICtowMu14Q==", "da3d4145-38ce-4360-b81c-d3a6adde1798" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95d3d71e-8a1d-4cc6-97bf-26d9fc3d2f72", "AQAAAAEAACcQAAAAEP2LO8uXVuQ+53nJSvqC4PTIWXtRdnzxh2sWVQTWt/rW76vva/Ns03Kn2AdWu/3h9g==", "66326c05-cdc0-426c-9205-b15541fc8d37" });
        }
    }
}
