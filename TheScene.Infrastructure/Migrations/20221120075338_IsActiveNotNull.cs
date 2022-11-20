using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class IsActiveNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "229d1d00-c50a-4076-988b-efb35b1def91", "AQAAAAEAACcQAAAAEPsjTjYNwj8NQK1p5IQc5bR3bATUpZlMAUzMLs7p63MUttAZYZJdIH0yUw5fg0AyCg==", "dfd92e7b-8cc9-450c-89db-9a860e519215" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0279369b-6982-4ca0-a1f0-d377a4628e07", "AQAAAAEAACcQAAAAEE9mv1sF2VFnyEWi7n/Sglh1xUbhQONrVLDVzznwL2ELyc4iyWXMetoxeMwu4lpsFQ==", "6274fdeb-8db6-4943-a607-7d5591155f76" });
        }
    }
}
