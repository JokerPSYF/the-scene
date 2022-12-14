using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9878d3-f564-4c59-a4a5-dcef8f79d147", "AQAAAAEAACcQAAAAEHgzSuHy1kyv1XKeX2KW0DcrYS82eAXSO1maeDDdxNyQCs6FUOYHFstQ2CkplQapBw==", "f1e0f2fe-78d9-440d-8103-5f3406450844" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "229d1d00-c50a-4076-988b-efb35b1def91", "AQAAAAEAACcQAAAAEPsjTjYNwj8NQK1p5IQc5bR3bATUpZlMAUzMLs7p63MUttAZYZJdIH0yUw5fg0AyCg==", "dfd92e7b-8cc9-450c-89db-9a860e519215" });
        }
    }
}
