using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class geolocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The first name of the user"),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The first name of the user"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfomanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfomanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perfomances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Actors = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PerfomanceTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfomances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfomances_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfomances_PerfomanceTypes_PerfomanceTypeId",
                        column: x => x.PerfomanceTypeId,
                        principalTable: "PerfomanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlaceTypeId = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_PlaceTypes_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfomanceId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    OccupiedSeats = table.Column<int>(type: "int", nullable: true),
                    FreeSeats = table.Column<int>(type: "int", nullable: true),
                    PricePerTicket = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPremiere = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Perfomances_PerfomanceId",
                        column: x => x.PerfomanceId,
                        principalTable: "Perfomances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "549fc033-7a1d-4f62-a213-987cf3fccd42", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a15400e-4991-4d66-87df-05a82c3bf851", 0, "a44a3088-9e7b-491d-8ffc-04387a929072", "AppUser", "teo@mail.com", false, "Todor", true, "Vasilev", false, null, "TEO@MAIL.COM", "TEO", "AQAAAAEAACcQAAAAEOUwVsSmGxUkuxOhbQ2a1zO4eVs3Utc5ETRlV+4RvInpgYNvKOdhPdSCDYU7vTr3Hg==", null, false, "84fc3742-966b-4bc1-ab01-cf62dc73dc26", false, "Teo" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Horror" },
                    { 6, "Mystery" },
                    { 7, "Romance" },
                    { 8, "Thriller" },
                    { 9, "Western" },
                    { 10, "Pop music" },
                    { 11, "Hip hop music" },
                    { 12, "Rock music" },
                    { 13, "Folk music" },
                    { 14, "Pop Folk music" },
                    { 15, "Jazz music" },
                    { 16, "Electronic music" },
                    { 17, "Classical music" },
                    { 18, "Christian music" }
                });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b97379a1-4a4b-4cdb-b57f-edf338d73730", "7a15400e-4991-4d66-87df-05a82c3bf851" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "IsActive", "Link", "Name", "PlaceTypeId", "Seats" },
                values: new object[,]
                {
                    { 1, "pl. \"Troykata\" 1, 8000 Burgas Center, Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d505.2189479926242!2d27.46955384608908!3d42.498052194717765!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694be410c32c9%3A0x1887194803bffd9f!2z0JrRg9C70YLRg9GA0LXQvSDQtNC-0Lwg0J3QpdCa!5e0!3m2!1sen!2sbg!4v1671710527425!5m2!1sen!2sbg", "Културен дом НХК", 2, 400 },
                    { 2, "48 улица „Христо Ботев“, 8000 Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1485726.0365802157!2d25.608665091216206!3d43.33919270804973!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694bee7bc0013%3A0x64d7652ab70a143!2sMilitary%20Hotel!5e0!3m2!1sen!2sbg!4v1671710657625!5m2!1sen!2sbg", "Military Hotel", 2, 300 },
                    { 3, "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.9731228793357!2d27.46557931575126!3d42.49212403474332!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b87b8e8175%3A0x162a847dd72fc4be!2sDrama%20Theatre%20Adriana%20Budevska!5e0!3m2!1sen!2sbg!4v1671711023393!5m2!1sen!2sbg", "Drama Theatre Adriana Budevska", 2, 320 },
                    { 4, "Demokratsia Blvd 94, 8001 Burgas Center, Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.767603047012!2d27.473731165751342!3d42.49649308446668!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694ea2b320899%3A0xd212510bf1f13ad2!2sOpen-air%20theater!5e0!3m2!1sen!2sbg!4v1671711176033!5m2!1sen!2sbg", "Open-air theater", 3, 1970 },
                    { 5, "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.0000352977227!2d27.452702515751575!3d42.51280723343363!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a693634968f40b%3A0x33fae8c02fef63e6!2sCinema%20City!5e0!3m2!1sen!2sbg!4v1671711225819!5m2!1sen!2sbg", "Cinema City", 1, 153 },
                    { 6, "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23527.987394558437!2d27.43738163133954!3d42.51284146838338!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a69536d031a19f%3A0xee7a2bf8742be5d!2z0JTRitGA0LbQsNCy0LXQvSDQutGD0LrQu9C10L0g0YLQtdCw0YLRitGA!5e0!3m2!1sen!2sbg!4v1671711273085!5m2!1sen!2sbg", "Държавен куклен театър", 2, 200 },
                    { 7, "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.8628304682!2d27.4671644157514!3d42.494468734594896!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b8b420f267%3A0x2bed66575402c90b!2sThe%20Opera%20House!5e0!3m2!1sen!2sbg!4v1671711341381!5m2!1sen!2sbg", "The Opera House", 2, 300 }
                });

            migrationBuilder.InsertData(
                table: "Perfomances",
                columns: new[] { "Id", "Actors", "Description", "Director", "GenreId", "ImageURL", "IsActive", "PerfomanceTypeId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Стефан Василев, Таня Памукчиева", "„Талантино“ предупреждава: Страстта може да бъде много опасна!\r\nПсихопат – сериен убиец и жертва – психолог, разказват една история. История, в която истината и лъжата са винаги на тънка и опасна граница. В търсенето на причината, която ги е довела до тази екстремна ситуация, ролята на палач преминава от ръка на ръка и това, което изглежда като предсказуем край, търпи обрат след обрат. Трябва ли да превърнем живота си в една трагична история, за да го разберем? Ще получи ли психопата желаната си терапия или ще вземе поредната си жертва?", "Станимир Карагьозов", 8, "https://scontent-sof1-2.xx.fbcdn.net/v/t39.30808-6/312262525_523539703113345_5372908178241038288_n.jpg?stp=dst-jpg_s960x960&_nc_cat=110&ccb=1-7&_nc_sid=340051&_nc_ohc=sqvojeCwuhUAX-sD6f5&_nc_ht=scontent-sof1-2.xx&oh=00_AfD9_3plCjvaqT6IiWveG_8HOaVI37UEvZJ8PuuE4Hw3Bg&oe=637B30E4", true, 2, "Верига от думи", null },
                    { 2, "Sosie Bacon, Jessie T. Usher, Kyle Gallner", "After witnessing a bizarre, traumatic incident involving a patient, Dr. Rose Cotter starts experiencing frightening occurrences that she can't explain. Rose must confront her troubling past in order to survive and escape her horrifying new reality.", "Parker Finn", 5, "https://www.cinemacity.bg/xmedia-cw/repo/feats/posters/5170S2R-lg.jpg", true, 1, "Smile", 2022 },
                    { 3, "Йоана Кадийска, Яни Николов, Йордан Христозов", "Оригинални декори пренасят присъстващите в най-големия храм на древна Елада и в покоите на Елена. Изрисуваните по тях известни случки от ловни и любовни сцени използват техниката на гръцкия вазопис.", "Александър Текелиев", 2, "https://www.programata.bg/img/gallery/event_50529.jpg?997794843", true, 2, "La belle Hellene", null },
                    { 4, null, "Едно неочаквано претворяване на познатия сюжет от новелата Кармен на Мериме и любимата музика от едноименната опера на Бизе. Спектакъл за неустоимата страст на Кармен, търсеща всепоглъщаща любов или просто хладна любовна игра на живот и смърт.", "Боряна Сечанова", 7, "https://www.programata.bg/img/gallery/event_107123.jpg?1331961416", true, 4, "Колекция Кармен", null },
                    { 5, null, "Самюел Андре Мадсън израства в религиозно семейство в провинция в Дания и се учи да свири на бас и барабани в църквата там, а сега е един от най-успешните диджеи и лейбъл мениджъри.", null, 16, "https://www.programata.bg/img/gallery/event_107182.jpg?630607749", true, 5, "Ritual Gatherings present S.A.M.", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "FreeSeats", "IsActive", "IsPremiere", "LocationId", "OccupiedSeats", "PerfomanceId", "PricePerTicket" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 6, 0, 1, 12m },
                    { 2, new DateTime(2022, 11, 24, 22, 30, 0, 0, DateTimeKind.Unspecified), null, true, false, 5, 0, 2, 14m },
                    { 3, new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 7, 0, 3, 12m },
                    { 4, new DateTime(2022, 12, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 7, 0, 4, 25m },
                    { 5, new DateTime(2022, 12, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 4, 0, 5, 40m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PerfomanceId",
                table: "Events",
                column: "PerfomanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PlaceTypeId",
                table: "Locations",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfomances_GenreId",
                table: "Perfomances",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfomances_PerfomanceTypeId",
                table: "Perfomances",
                column: "PerfomanceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Perfomances");

            migrationBuilder.DropTable(
                name: "PlaceTypes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "PerfomanceTypes");
        }
    }
}
