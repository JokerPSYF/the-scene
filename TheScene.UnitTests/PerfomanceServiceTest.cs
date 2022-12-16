using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;
using TheScene.Infrastructure.Data.Entities;

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

        [Test]
        public async Task PerfomanceDeleteTest()
        {
            await perfService.Delete(1);

            var loc = repo.AllReadonly<Perfomance>();

            await repo.SaveChangesAsync();

            Assert.That(loc, Is.Not.Null);
            Assert.That(loc.Any(l => l.Title == "Верига от думи" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Director == "Станимир Карагьозов" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Genre.Name == "Thriller" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.PerfomanceType.Name == "Theatrical play" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Id == 1 && l.IsActive), Is.EqualTo(false));
        }

        [Test]
        public async Task PerfomanceDetailsByIdTest()
        {
            var result = await perfService.DetailsById(5);

            Assert.That(result.Id, Is.EqualTo(5));
            Assert.That(result.Title, Is.EqualTo("Ritual Gatherings present S.A.M."));
            Assert.That(result.GenreId, Is.EqualTo(16));
            Assert.That(result.Genre, Is.EqualTo("Electronic music"));
            Assert.That(result.PerfomanceType, Is.EqualTo("Concert"));
            Assert.That(result.PerfomanceTypeId, Is.EqualTo(5));
            Assert.That(result.ImageURL, Is.EqualTo("https://www.programata.bg/img/gallery/event_107182.jpg?630607749"));
            Assert.That(result.Description, 
                Is.EqualTo("Самюел Андре Мадсън израства в религиозно семейство в провинция в Дания и се учи да свири на бас и барабани в църквата там, а сега е един от най-успешните диджеи и лейбъл мениджъри."));
        }

        [Test]
        public async Task PerfomancerEditTest()
        {
            var perfBefore = await this.repo.GetByIdAsync<Perfomance>(5);

            Assert.That(perfBefore.Id, Is.EqualTo(5));
            Assert.That(perfBefore.Title, Is.EqualTo("Ritual Gatherings present S.A.M."));
            Assert.That(perfBefore.GenreId, Is.EqualTo(16));
            Assert.That(perfBefore.PerfomanceTypeId, Is.EqualTo(5));
            Assert.That(perfBefore.ImageURL, Is.EqualTo("https://www.programata.bg/img/gallery/event_107182.jpg?630607749"));
            Assert.That(perfBefore.Description,
                Is.EqualTo("Самюел Андре Мадсън израства в религиозно семейство в провинция в Дания и се учи да свири на бас и барабани в църквата там, а сега е един от най-успешните диджеи и лейбъл мениджъри."));

            var perfModel = new PerfomanceModel()
            {
                Title = "Test",
                Director = "Testchov",
                GenreId = 1,
                Actors = "Dj Stancho",
                Description = "Description",
                Year = 1999,
                ImageURL = "Image"
            };
            await perfService.Edit(1, perfModel);

            var perf = await this.repo.GetByIdAsync<Perfomance>(1);
            await repo.SaveChangesAsync();

            Assert.That(perf, Is.Not.Null);
            Assert.That(perf.Title, Is.EqualTo("Test"));
            Assert.That(perf.Director, Is.EqualTo("Testchov"));
            Assert.That(perf.GenreId, Is.EqualTo(1));
            Assert.That(perf.Actors, Is.EqualTo("Dj Stancho"));
            Assert.That(perf.Description, Is.EqualTo("Description"));
            Assert.That(perf.Year, Is.EqualTo(1999));
            Assert.That(perf.ImageURL, Is.EqualTo("Image"));
        }

        [Test]
        public async Task PerfExistsTest()
        {
            Assert.That(await perfService.Exists(1), Is.EqualTo(true));
            Assert.That(await perfService.Exists(10), Is.EqualTo(false));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
