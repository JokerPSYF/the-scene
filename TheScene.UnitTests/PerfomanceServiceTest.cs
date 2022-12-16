using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.UnitTests
{
    [TestFixture]
    public class PerfomanceServiceTest
    {
        private IRepository repo;
        private IPerfomanceService perfService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PerfomanceDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            this.repo = new Repository(context);
            perfService = new PerfomanceService(this.repo);
        }

        [Test]
        public async Task GetAllPerfomanceTest()
        {
            var result = await perfService.All();

            Assert.That(5, Is.EqualTo(result.TotalCount));
            Assert.That(result.Collection.Any(l => l.Id == 5
            && l.Title == "Ritual Gatherings present S.A.M."), Is.True);
            Assert.That(result.Collection.Any(l => l.Id == 4
            && l.ImageUrl == "https://www.programata.bg/img/gallery/event_107123.jpg?1331961416"), Is.True);
            Assert.That(result.Collection.Any(l => l.Id == 3
            && l.Actors == "Йоана Кадийска, Яни Николов, Йордан Христозов"), Is.True);
            Assert.That(result.Collection.Any(l => l.Id == 2
            && l.Director == "Parker Finn"
            && l.Year == 2022), Is.True);
            Assert.That(result.Collection.Any(l => l.Id == 1
            && l.Genre == "Thriller"
            && l.PefomanceType == "Theatrical play"), Is.True);
            Assert.That(result.Collection.Count, Is.EqualTo(5));
        }

        [Test]
        public async Task CreatePerfomanceTest()
        {
            var perfModel = new PerfomanceModel()
            {
                Title = "Test",
                Director = "Testchov",
                GenreId = 1,
            };

            var result = await perfService.Create(perfModel);
            await repo.SaveChangesAsync();

            Assert.That(result, Is.EqualTo(6));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
