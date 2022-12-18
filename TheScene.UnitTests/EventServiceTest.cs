using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.UnitTests
{
    [TestFixture]
    public class EventServiceTest
    {
        private IRepository repo;
        private IEventService eventService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("EventDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            this.repo = new Repository(context);
            eventService = new EventService(this.repo);
        }

        [Test]
        public async Task GetAllEventsTest()
        {

            var result = await eventService.All();

            if (DateTime.Today <= new DateTime(2022, 12, 18))
            {
                Assert.That(2, Is.EqualTo(result.TotalCount));
                Assert.That(result.Collection.Any(l => l.Id == 5), Is.True);
                Assert.That(result.Collection.Any(l => l.Id == 4), Is.True);
                Assert.That(result.Collection.Count, Is.EqualTo(2));
            }
            else
            {
                Assert.That(0, Is.EqualTo(result.TotalCount));
                Assert.That(result.Collection.Any(l => l.Id == 6), Is.False);
                Assert.That(result.Collection.Count, Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CreateEventTest()
        {
            var evModel = new EventModel()
            {
                PerfomanceId = 1,
                LocationId = 2,
                PricePerTicket = 12.50m,
                Date = new DateTime(2022, 12, 20, 22, 00, 00),
                IsPremiere = false
            };

            var result = await eventService.Create(evModel);
            await repo.SaveChangesAsync();

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public async Task EventDeleteTest()
        {
            await eventService.Delete(1);

            var loc = repo.AllReadonly<Event>();

            await repo.SaveChangesAsync();

            Assert.That(loc, Is.Not.Null);
            Assert.That(loc.Any(l => l.Perfomance.Title == "Верига от думи" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Location.Name == "Държавен куклен театър" && l.Id == 1), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Id == 1 && l.IsActive), Is.EqualTo(false));
        }

        [Test]
        public async Task EventDetailsByIdTest()
        {
            var result = await eventService.DetailsById(1);

            Assert.That(result.Perfomance.Title, Is.EqualTo("Верига от думи"));
            Assert.That(result.LocationName, Is.EqualTo("Държавен куклен театър"));
            Assert.That(result.PricePerTicket, Is.EqualTo(12));
            Assert.That(result.Date, Is.EqualTo(new DateTime(2022, 12, 13, 19, 00, 00)));
        }

        [Test]
        public async Task EventEditTest()
        {
            var evBefore = await this.repo.GetByIdAsync<Event>(1);

            Assert.That(evBefore, Is.Not.Null);
            Assert.That(evBefore.PerfomanceId, Is.EqualTo(1));
            Assert.That(evBefore.LocationId, Is.EqualTo(6));
            Assert.That(evBefore.PricePerTicket, Is.EqualTo(12));
            Assert.That(evBefore.IsPremiere, Is.EqualTo(false));
            Assert.That(evBefore.Date, Is.EqualTo(new DateTime(2022, 12, 13, 19, 00, 00)));

            var evModel = new EventModel()
            {
                PerfomanceId = 2,
                LocationId = 3,
                PricePerTicket = 5,
                IsPremiere = true,
                Date = new DateTime(2022, 12, 18, 19, 30, 00)
            };
            await eventService.Edit(1, evModel);

            var ev = await this.repo.GetByIdAsync<Event>(1);
            await repo.SaveChangesAsync();

            Assert.That(ev, Is.Not.Null);
            Assert.That(ev.PerfomanceId, Is.EqualTo(2));
            Assert.That(ev.LocationId, Is.EqualTo(3));
            Assert.That(ev.PricePerTicket, Is.EqualTo(5));
            Assert.That(ev.IsPremiere, Is.EqualTo(true));
            Assert.That(ev.Date, Is.EqualTo(new DateTime(2022, 12, 18, 19, 30, 00)));
        }

        [Test]
        public async Task EventExistsTest()
        {
            Assert.That(await eventService.Exists(1), Is.EqualTo(true));
            Assert.That(await eventService.Exists(10), Is.EqualTo(false));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
