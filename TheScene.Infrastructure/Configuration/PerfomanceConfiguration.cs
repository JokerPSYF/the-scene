using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Infrastructure.Configuration
{
    public class PerfomanceConfiguration : IEntityTypeConfiguration<Perfomance>
    {
        public void Configure(EntityTypeBuilder<Perfomance> builder)
        {
            builder.HasData(CreatePerfomances());
        }

        private List<Perfomance> CreatePerfomances()
        {
            var perfomances = new List<Perfomance>()
            {
                new Perfomance()
                {
                    Id = 1,
                    Title = "Верига от думи",
                    Director = "Станимир Карагьозов",
                    GenreId = 8,
                    Actors = "Стефан Василев, Таня Памукчиева",
                    PerfomanceTypeId = 2,
                    Description = "„Талантино“ предупреждава: Страстта може да бъде много опасна!\r\nПсихопат – сериен убиец и жертва – психолог, разказват една история. История, в която истината и лъжата са винаги на тънка и опасна граница. В търсенето на причината, която ги е довела до тази екстремна ситуация, ролята на палач преминава от ръка на ръка и това, което изглежда като предсказуем край, търпи обрат след обрат. Трябва ли да превърнем живота си в една трагична история, за да го разберем? Ще получи ли психопата желаната си терапия или ще вземе поредната си жертва?",
                    ImageURL = "https://scontent-sof1-2.xx.fbcdn.net/v/t39.30808-6/312262525_523539703113345_5372908178241038288_n.jpg?stp=dst-jpg_s960x960&_nc_cat=110&ccb=1-7&_nc_sid=340051&_nc_ohc=sqvojeCwuhUAX-sD6f5&_nc_ht=scontent-sof1-2.xx&oh=00_AfD9_3plCjvaqT6IiWveG_8HOaVI37UEvZJ8PuuE4Hw3Bg&oe=637B30E4"
                },

                new Perfomance()
                {
                    Id = 2,
                    Title = "Smile",
                    Director = "Parker Finn",
                    GenreId = 5,
                    Actors = "Sosie Bacon, Jessie T. Usher, Kyle Gallner",
                    PerfomanceTypeId = 1,
                    Year = 2022,
                    Description = "After witnessing a bizarre, traumatic incident involving a patient, Dr. Rose Cotter starts experiencing frightening occurrences that she can't explain. Rose must confront her troubling past in order to survive and escape her horrifying new reality.",
                    ImageURL = "https://www.cinemacity.bg/xmedia-cw/repo/feats/posters/5170S2R-lg.jpg"
                },
                
                new Perfomance()
                {
                    Id = 3,
                    Title = "La belle Hellene",
                    Director = "Александър Текелиев",
                    GenreId = 2,
                    Actors = "Йоана Кадийска, Яни Николов, Йордан Христозов",
                    PerfomanceTypeId = 2,
                    Description = "Оригинални декори пренасят присъстващите в най-големия храм на древна Елада и в покоите на Елена. Изрисуваните по тях известни случки от ловни и любовни сцени използват техниката на гръцкия вазопис.",
                    ImageURL = "https://www.programata.bg/img/gallery/event_50529.jpg?997794843"
                },

                new Perfomance()
                {
                    Id = 4,
                    Title = "Колекция Кармен",
                    Director = "Боряна Сечанова",
                    GenreId = 7,
                    PerfomanceTypeId = 4,
                    Description = "Едно неочаквано претворяване на познатия сюжет от новелата Кармен на Мериме и любимата музика от едноименната опера на Бизе. Спектакъл за неустоимата страст на Кармен, търсеща всепоглъщаща любов или просто хладна любовна игра на живот и смърт.",
                    ImageURL = "https://www.programata.bg/img/gallery/event_107123.jpg?1331961416"
                },

                new Perfomance()
                {
                    Id = 5,
                    Title = "Ritual Gatherings present S.A.M.",
                    GenreId = 16,
                    PerfomanceTypeId = 5,
                    Description = "Самюел Андре Мадсън израства в религиозно семейство в провинция в Дания и се учи да свири на бас и барабани в църквата там, а сега е един от най-успешните диджеи и лейбъл мениджъри.",
                    ImageURL = "https://www.programata.bg/img/gallery/event_107182.jpg?630607749"
                }
            };
            return perfomances;
        }
    }
}
