using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f0f04d5-8d3f-47ce-9850-05962ad1fc46", "AQAAAAEAACcQAAAAEIRVHUm210fP1s67cDqnevlml4pAdkX+nuCOs5c3fS5Ljz2gk0invQ7NdmQOSwVHbA==", "51927319-7578-4f77-acf7-f3ea0c253def" });

            migrationBuilder.InsertData(
                table: "PlaceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cinema" },
                    { 2, "Theater" },
                    { 3, "Open air theater" },
                    { 4, "Stadium" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "IsActive", "Name", "PlaceTypeId", "Seats" },
                values: new object[,]
                {
                    { 1, "pl. \"Troykata\" 1, 8000 Burgas Center, Burgas", true, "Културен дом НХК", 2, 400 },
                    { 2, "48 улица „Христо Ботев“, 8000 Burgas", true, "Military Hotel", 2, 300 },
                    { 3, "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas", true, "Drama Theatre Adriana Budevska", 2, 320 },
                    { 4, "Demokratsia Blvd 94, 8001 Burgas Center, Burgas", true, "Open-air theater", 3, 1970 },
                    { 5, "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas", true, "Cinema City", 1, 153 },
                    { 6, "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas", true, "Държавен куклен театър", 2, 200 },
                    { 7, "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas", true, "The Opera House", 2, 300 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de87f56a-2bfa-4009-bce8-f23d39cf65f1", "AQAAAAEAACcQAAAAELycZ6zquqkaZZOyPzkdT/1WxL39OaGUDmLXmaHJshBazN0TWk7rEPkvPKOkT/hIsw==", "c20713e0-471a-4826-9eb0-12fd1a2b6f22" });
        }
    }
}
