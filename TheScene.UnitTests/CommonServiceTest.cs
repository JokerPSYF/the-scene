using Microsoft.EntityFrameworkCore;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data;
using TheScene.Core.Interface;

namespace TheScene.UnitTests
{
    [TestFixture]
    public class CommonServiceTest
    {
        private IRepository repo;
        private ICommonService comService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CommonDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            this.repo = new Repository(context);
            comService = new CommonService(this.repo);
        }

        #region Genre

        [Test]
        public async Task AllGenresTest()
        {
            var result = await comService.AllGenres();

            Assert.That(18, Is.EqualTo(result.Count()));
            Assert.That(result.Any(g => g.Id == 1 && g.DisplayName == "Action"), Is.True);
            Assert.That(result.Any(g => g.Id == 2 && g.DisplayName == "Comedy"), Is.True);
            Assert.That(result.Any(g => g.Id == 3 && g.DisplayName == "Drama"), Is.True);
            Assert.That(result.Any(g => g.Id == 4 && g.DisplayName == "Fantasy"), Is.True);
            Assert.That(result.Any(g => g.Id == 5 && g.DisplayName == "Horror"), Is.True);
            Assert.That(result.Any(g => g.Id == 6 && g.DisplayName == "Mystery"), Is.True);
            Assert.That(result.Any(g => g.Id == 7 && g.DisplayName == "Romance"), Is.True);
            Assert.That(result.Any(g => g.Id == 8 && g.DisplayName == "Thriller"), Is.True);
            Assert.That(result.Any(g => g.Id == 9 && g.DisplayName == "Western"), Is.True);
            Assert.That(result.Any(g => g.Id == 10 && g.DisplayName == "Pop music"), Is.True);
            Assert.That(result.Any(g => g.Id == 11 && g.DisplayName == "Hip hop music"), Is.True);
            Assert.That(result.Any(g => g.Id == 12 && g.DisplayName == "Rock music"), Is.True);
            Assert.That(result.Any(g => g.Id == 13 && g.DisplayName == "Folk music"), Is.True);
            Assert.That(result.Any(g => g.Id == 14 && g.DisplayName == "Pop Folk music"), Is.True);
            Assert.That(result.Any(g => g.Id == 15 && g.DisplayName == "Jazz music"), Is.True);
            Assert.That(result.Any(g => g.Id == 16 && g.DisplayName == "Electronic music"), Is.True);
            Assert.That(result.Any(g => g.Id == 17 && g.DisplayName == "Classical music"), Is.True);
            Assert.That(result.Any(g => g.Id == 18 && g.DisplayName == "Christian music"), Is.True);
        }

        [Test]
        public async Task AllGenreNameTest()
        {
            var result = await comService.AllGenresNames();

            Assert.That(18, Is.EqualTo(result.Count()));
            Assert.That(result.Any(g => g == "Action"), Is.True);
            Assert.That(result.Any(g => g == "Comedy"), Is.True);
            Assert.That(result.Any(g => g == "Drama"), Is.True);
            Assert.That(result.Any(g => g == "Fantasy"), Is.True);
            Assert.That(result.Any(g => g == "Horror"), Is.True);
            Assert.That(result.Any(g => g == "Mystery"), Is.True);
            Assert.That(result.Any(g => g == "Romance"), Is.True);
            Assert.That(result.Any(g => g == "Thriller"), Is.True);
            Assert.That(result.Any(g => g == "Western"), Is.True);
            Assert.That(result.Any(g => g == "Pop music"), Is.True);
            Assert.That(result.Any(g => g == "Hip hop music"), Is.True);
            Assert.That(result.Any(g => g == "Rock music"), Is.True);
            Assert.That(result.Any(g => g == "Folk music"), Is.True);
            Assert.That(result.Any(g => g == "Pop Folk music"), Is.True);
            Assert.That(result.Any(g => g == "Jazz music"), Is.True);
            Assert.That(result.Any(g => g == "Electronic music"), Is.True);
            Assert.That(result.Any(g => g == "Classical music"), Is.True);
            Assert.That(result.Any(g => g == "Christian music"), Is.True);
            Assert.That(result.Any(g => g == ""), Is.False);
        }

        [Test]
        public async Task GenreExistsTest()
        {
            Assert.That(await comService.GenreExists(0), Is.False);
            Assert.That(await comService.GenreExists(1), Is.True);
            Assert.That(await comService.GenreExists(2), Is.True);
            Assert.That(await comService.GenreExists(3), Is.True);
            Assert.That(await comService.GenreExists(4), Is.True);
            Assert.That(await comService.GenreExists(5), Is.True);
            Assert.That(await comService.GenreExists(6), Is.True);
            Assert.That(await comService.GenreExists(7), Is.True);
            Assert.That(await comService.GenreExists(8), Is.True);
            Assert.That(await comService.GenreExists(9), Is.True);
            Assert.That(await comService.GenreExists(10), Is.True);
            Assert.That(await comService.GenreExists(11), Is.True);
            Assert.That(await comService.GenreExists(12), Is.True);
            Assert.That(await comService.GenreExists(13), Is.True);
            Assert.That(await comService.GenreExists(14), Is.True);
            Assert.That(await comService.GenreExists(15), Is.True);
            Assert.That(await comService.GenreExists(16), Is.True);
            Assert.That(await comService.GenreExists(17), Is.True);
            Assert.That(await comService.GenreExists(18), Is.True);
            Assert.That(await comService.GenreExists(19), Is.False);
            Assert.That(await comService.GenreExists(20), Is.False);
        }
        #endregion

        #region Location

        [Test]
        public async Task AllLocationsTest()
        {
            var result = await comService.AllLocations();

            Assert.That(7, Is.EqualTo(result.Count()));
            Assert.That(result.Any(l => l.Id == 1 && l.DisplayName == "Културен дом НХК"), Is.True);
            Assert.That(result.Any(l => l.Id == 2 && l.DisplayName == "Military Hotel"), Is.True);
            Assert.That(result.Any(l => l.Id == 3 && l.DisplayName == "Drama Theatre Adriana Budevska"), Is.True);
            Assert.That(result.Any(l => l.Id == 4 && l.DisplayName == "Open-air theater"), Is.True);
            Assert.That(result.Any(l => l.Id == 5 && l.DisplayName == "Cinema City"), Is.True);
            Assert.That(result.Any(l => l.Id == 6 && l.DisplayName == "Държавен куклен театър"), Is.True);
            Assert.That(result.Any(l => l.Id == 7 && l.DisplayName == "The Opera House"), Is.True);          
        }

        [Test]
        public async Task AllLocationsNameTest()
        {
            var result = await comService.AllLocationsNames();

            Assert.That(7, Is.EqualTo(result.Count()));
            Assert.That(result.Any(l => l == "Културен дом НХК"), Is.True);
            Assert.That(result.Any(l => l == "Military Hotel"), Is.True);
            Assert.That(result.Any(l => l == "Drama Theatre Adriana Budevska"), Is.True);
            Assert.That(result.Any(l => l == "Open-air theater"), Is.True);
            Assert.That(result.Any(l => l == "Cinema City"), Is.True);
            Assert.That(result.Any(l => l == "Държавен куклен театър"), Is.True);
            Assert.That(result.Any(l => l == "The Opera House"), Is.True);
            Assert.That(result.Any(l => l == ""), Is.False);
        }

        [Test]
        public async Task LocationExistsTest()
        {
            Assert.That(await comService.LocationExists(0), Is.False);
            Assert.That(await comService.LocationExists(1), Is.True);
            Assert.That(await comService.LocationExists(2), Is.True);
            Assert.That(await comService.LocationExists(3), Is.True);
            Assert.That(await comService.LocationExists(4), Is.True);
            Assert.That(await comService.LocationExists(5), Is.True);
            Assert.That(await comService.LocationExists(6), Is.True);
            Assert.That(await comService.LocationExists(7), Is.True);
            Assert.That(await comService.LocationExists(8), Is.False);
            Assert.That(await comService.LocationExists(9), Is.False);
            Assert.That(await comService.LocationExists(10), Is.False);
        }
        #endregion

        #region Perfomance

        [Test]
        public async Task AllPerfomancesTest()
        {
            var result = await comService.AllPerfomances();

            Assert.That(5, Is.EqualTo(result.Count()));
            Assert.That(result.Any(p => p.Id == 1 && p.DisplayName == "Верига от думи"), Is.True);
            Assert.That(result.Any(p => p.Id == 2 && p.DisplayName == "Smile"), Is.True);
            Assert.That(result.Any(p => p.Id == 3 && p.DisplayName == "La belle Hellene"), Is.True);
            Assert.That(result.Any(p => p.Id == 4 && p.DisplayName == "Колекция Кармен"), Is.True);
            Assert.That(result.Any(p => p.Id == 5 && p.DisplayName == "Ritual Gatherings present S.A.M."), Is.True);
        }

        [Test]
        public async Task AllPerfomancesNameTest()
        {
            var result = await comService.AllPerfomancesNames();

            Assert.That(5, Is.EqualTo(result.Count()));
            Assert.That(result.Any(p => p == "Верига от думи"), Is.True);
            Assert.That(result.Any(p => p == "Smile"), Is.True);
            Assert.That(result.Any(p => p == "La belle Hellene"), Is.True);
            Assert.That(result.Any(p => p == "Колекция Кармен"), Is.True);
            Assert.That(result.Any(p => p == "Ritual Gatherings present S.A.M."), Is.True);
            Assert.That(result.Any(p => p == ""), Is.False);
        }

        [Test]
        public async Task PerfomanceExistsTest()
        {
            Assert.That(await comService.PerfomancesExists(0), Is.False);
            Assert.That(await comService.PerfomancesExists(1), Is.True);
            Assert.That(await comService.PerfomancesExists(2), Is.True);
            Assert.That(await comService.PerfomancesExists(3), Is.True);
            Assert.That(await comService.PerfomancesExists(4), Is.True);
            Assert.That(await comService.PerfomancesExists(5), Is.True);
            Assert.That(await comService.PerfomancesExists(6), Is.False);
            Assert.That(await comService.PerfomancesExists(7), Is.False);
            Assert.That(await comService.PerfomancesExists(8), Is.False);
            Assert.That(await comService.PerfomancesExists(9), Is.False);
            Assert.That(await comService.PerfomancesExists(10), Is.False);
        }
        #endregion

        #region Perfomance Type

        [Test]
        public async Task AllPerfomanceTypesTest()
        {
            var result = await comService.AllPerfomancesTypes();

            Assert.That(5, Is.EqualTo(result.Count()));
            Assert.That(result.Any(x => x.Id == 1 && x.DisplayName == "Movie"), Is.True);
            Assert.That(result.Any(x => x.Id == 2 && x.DisplayName == "Theatrical play"), Is.True);
            Assert.That(result.Any(x => x.Id == 3 && x.DisplayName == "Opera"), Is.True);
            Assert.That(result.Any(x => x.Id == 4 && x.DisplayName == "Ballet"), Is.True);
            Assert.That(result.Any(x => x.Id == 5 && x.DisplayName == "Concert"), Is.True);
        }

        [Test]
        public async Task AllPerfomanceTypesNameTest()
        {
            var result = await comService.AllPerfomanceTypesNames();

            Assert.That(5, Is.EqualTo(result.Count()));
            Assert.That(result.Any(x => x == "Movie"), Is.True);
            Assert.That(result.Any(x => x == "Theatrical play"), Is.True);
            Assert.That(result.Any(x => x == "Opera"), Is.True);
            Assert.That(result.Any(x => x == "Ballet"), Is.True);
            Assert.That(result.Any(x => x == "Concert"), Is.True);
            Assert.That(result.Any(x => x == ""), Is.False);
        }

        [Test]
        public async Task PerfomanceTypeExistsTest()
        {
            Assert.That(await comService.PerfomanceTypesExists(0), Is.False);
            Assert.That(await comService.PerfomanceTypesExists(1), Is.True);
            Assert.That(await comService.PerfomanceTypesExists(2), Is.True);
            Assert.That(await comService.PerfomanceTypesExists(3), Is.True);
            Assert.That(await comService.PerfomanceTypesExists(4), Is.True);
            Assert.That(await comService.PerfomanceTypesExists(5), Is.True);
            Assert.That(await comService.PerfomanceTypesExists(6), Is.False);
            Assert.That(await comService.PerfomanceTypesExists(7), Is.False);
            Assert.That(await comService.PerfomanceTypesExists(8), Is.False);
            Assert.That(await comService.PerfomanceTypesExists(9), Is.False);
            Assert.That(await comService.PerfomanceTypesExists(10), Is.False);
        }
        #endregion

        [Test]
        public async Task AllPlaceTypesTest()
        {
            var result = await comService.AllPlaceTypes();

            Assert.That(4, Is.EqualTo(result.Count()));
            Assert.That(result.Any(x => x.Id == 1 && x.DisplayName == "Cinema"), Is.True);
            Assert.That(result.Any(x => x.Id == 2 && x.DisplayName == "Theater"), Is.True);
            Assert.That(result.Any(x => x.Id == 3 && x.DisplayName == "Open air theater"), Is.True);
            Assert.That(result.Any(x => x.Id == 4 && x.DisplayName == "Stadium"), Is.True);
            Assert.That(result.Any(x => x.Id == 5 && x.DisplayName == ""), Is.False);
        }

        [Test]
        public async Task AllPlaceTypesNameTest()
        {
            var result = await comService.AllPlaceTypesNames();

            Assert.That(4, Is.EqualTo(result.Count()));
            Assert.That(result.Any(x => x == "Cinema"), Is.True);
            Assert.That(result.Any(x => x == "Theater"), Is.True);
            Assert.That(result.Any(x => x == "Open air theater"), Is.True);
            Assert.That(result.Any(x => x == "Stadium"), Is.True);
            Assert.That(result.Any(x => x == ""), Is.False);
        }

        [Test]
        public async Task PlaceTypeExistsTest()
        {
            Assert.That(await comService.PlaceTypeExists(0), Is.False);
            Assert.That(await comService.PlaceTypeExists(1), Is.True);
            Assert.That(await comService.PlaceTypeExists(2), Is.True);
            Assert.That(await comService.PlaceTypeExists(3), Is.True);
            Assert.That(await comService.PlaceTypeExists(4), Is.True);
            Assert.That(await comService.PlaceTypeExists(5), Is.False);
            Assert.That(await comService.PlaceTypeExists(6), Is.False);
            Assert.That(await comService.PlaceTypeExists(7), Is.False);
            Assert.That(await comService.PlaceTypeExists(8), Is.False);
            Assert.That(await comService.PlaceTypeExists(9), Is.False);
            Assert.That(await comService.PlaceTypeExists(10), Is.False);
        }

        #region Place Type


        #endregion

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
