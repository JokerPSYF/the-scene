using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeSeats",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OccupiedSeats",
                table: "Events");

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
                values: new object[] { "f0eacc77-d58e-4258-a989-032249a85847", "AQAAAAEAACcQAAAAEHnvBzt8n0butYWPMPZuztt+nZtPuNCw2JhGm4I5khEqmyr0sX5Typka2xd1YFDiNw==", "48f83095-57bf-4c3b-8da0-0e70156aa74c" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "IsActive", "IsPremiere", "LocationId", "PerfomanceId", "PricePerTicket" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), true, false, 6, 1, 12m },
                    { 2, new DateTime(2022, 11, 24, 22, 30, 0, 0, DateTimeKind.Unspecified), true, false, 5, 2, 14m },
                    { 3, new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), true, false, 7, 3, 12m },
                    { 4, new DateTime(2022, 12, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), true, false, 7, 4, 25m },
                    { 5, new DateTime(2022, 12, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), true, false, 4, 5, 40m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreeSeats",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OccupiedSeats",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc098994-e136-4caf-8b42-7247c1afd8b8", "AQAAAAEAACcQAAAAEPNj41+4Snecl3aHlNd6z44whqwtr8CvNmgVwwI+lgPzWUQlzssBzNwNfGP7XdhAiQ==", "548f4172-f37f-4a0f-97b7-b0638c44fbca" });
        }
    }
}
