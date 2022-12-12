using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Location;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.UnitTests
{
    [TestFixture]
    public class LocationServiceTests
    {
        private IRepository repo;
        private ILocationService locationService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("LocationDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            this.repo = new Repository(context);
            locationService = new LocationService(this.repo);
        }

        [Test]
        public async Task GetAllLocationsTest()
        {
            string? placeType = null;
            string? searchTerm = null;
            int currentPage = 1;
            int locationPerPage = 10;

            var result = await locationService.AllLocationsInfo(placeType, searchTerm, currentPage, locationPerPage);

            Assert.That(7, Is.EqualTo(result.TotalCount));
            Assert.That(result.Collection.Any(l => l.Id == 1), Is.True);
            Assert.That(result.Collection.Count, Is.EqualTo(7));
        }

        [Test]
        public async Task CreateLocationTest()
        {
            var locModel = new LocationModel()
            {
                Name = "Test",
                Address = "Address test",
                Seats = 2,
                PlaceTypeId = 2,
                PlaceTypeName = "idk"
            };

            var result = await locationService.CreateLocation(locModel);
            await repo.SaveChangesAsync();

            Assert.That(result, Is.Not.EqualTo(1));
        }

        [Test]
        public async Task LocationDetailsByIdTest()
        {
            var result = await locationService.LocationDetailsById(1);

            Assert.That(result.Name, Is.EqualTo("Културен дом НХК"));
            Assert.That(result.Address, Is.EqualTo("pl. \"Troykata\" 1, 8000 Burgas Center, Burgas"));
            Assert.That(result.PlaceTypeId, Is.EqualTo(2));
            Assert.That(result.Seats, Is.EqualTo(400));
        }

        [Test]
        public async Task LocationEditTest()
        {
            var locModel = new LocationModel()
            {
                Name = "Публичен дом НХК",
                Address = "pl. \"Troykata\" 1, 1234 Burgas Center, Burgas",
                PlaceTypeId = 3,
                Seats = 567
            };
            await locationService.LocationEdit(1, locModel);

            var loc = await this.repo.GetByIdAsync<Location>(1);
            await repo.SaveChangesAsync();

            Assert.That(loc, Is.Not.Null);
            Assert.That(loc.Name, Is.EqualTo("Публичен дом НХК"));
            Assert.That(loc.Address, Is.EqualTo("pl. \"Troykata\" 1, 1234 Burgas Center, Burgas"));
            Assert.That(loc.PlaceTypeId, Is.EqualTo(3));
            Assert.That(loc.Seats, Is.EqualTo(567));
        }

        [Test]
        public async Task LocationDeleteTest()
        {
            await locationService.LocationDelete(7);

            var loc = repo.AllReadonly<Location>();

            await repo.SaveChangesAsync();

            Assert.That(loc, Is.Not.Null);
            Assert.That(loc.Any(l => l.Name == "The Opera House"), Is.EqualTo(true));
            Assert.That(loc.Any(l => l.Id == 7 && l.IsActive), Is.EqualTo(false));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
