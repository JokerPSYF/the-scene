using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    public partial class seedPerfomance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc098994-e136-4caf-8b42-7247c1afd8b8", "AQAAAAEAACcQAAAAEPNj41+4Snecl3aHlNd6z44whqwtr8CvNmgVwwI+lgPzWUQlzssBzNwNfGP7XdhAiQ==", "548f4172-f37f-4a0f-97b7-b0638c44fbca" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfomances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perfomances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perfomances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Perfomances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Perfomances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a15400e-4991-4d66-87df-05a82c3bf851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdbe96da-741e-46c6-b192-ea897374d7d2", "AQAAAAEAACcQAAAAEHCQTHdne6QBoD7y3cpYM5W7phc7mZubqBtzk3NJBPDdyvM8wKcanPe7rT2PX2IXAA==", "503c774c-d14a-4708-a962-e9606a383fc3" });
        }
    }
}
