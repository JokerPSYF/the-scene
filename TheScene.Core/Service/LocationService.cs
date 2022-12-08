using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Core.Models.Location;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class LocationService : ILocationService
    {
        private readonly IRepository repository;

        public LocationService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<QueryModel<LocationModel>> AllLocationsInfo(
            string? placeType = null, string? searchTerm = null,
            int currentPage = 1, int locationPerPage = 10)
        {

            var result = new QueryModel<LocationModel>();
            var locs = repository.AllReadonly<Location>()
                .Where(l => l.IsActive);


            if (!string.IsNullOrEmpty(placeType))
                locs = locs.Where(e => e.PlaceType.Name == placeType);

            if (!string.IsNullOrEmpty(searchTerm))
            {

                searchTerm = $"%{searchTerm.ToLower()}%";

                locs = locs
                    .Where(e =>
                        EF.Functions.Like(e.Name.ToLower(), searchTerm) ||
                        EF.Functions.Like(e.Address.ToLower(), searchTerm) ||
                        EF.Functions.Like(e.Seats!.ToString()!, searchTerm) ||
                        EF.Functions.Like(e.PlaceType.Name.ToLower(), searchTerm));


            }

            result.Collection = await locs
                .Skip((currentPage - 1) * locationPerPage)
                .Take(locationPerPage)
                .Select(e => new LocationModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Address = e.Address,
                    Seats = e.Seats,
                    PlaceTypeName = e.PlaceType.Name,
                })
                .ToListAsync();

            result.TotalCount = await locs.CountAsync();

            return result;

        }

        public async Task<int> CreateLocation(LocationModel model)
        {
            var locationEntity = new Location()
            {
                Name = model.Name,
                Address = model.Address,
                Seats = model.Seats,
                PlaceTypeId = model.PlaceTypeId
            };

            await repository.AddAsync(locationEntity);
            await repository.SaveChangesAsync();

            return locationEntity.Id;
        }

        public async Task<LocationModel> LocationDetailsById(int id)
        {
            var result = await repository.AllReadonly<Location>()
                .Where(l => l.IsActive && l.Id == id)
                .Select(l => new LocationModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Address = l.Address,
                    Seats = l.Seats,
                    PlaceTypeId = l.PlaceTypeId,
                    PlaceTypeName = l.PlaceType.Name
                }).FirstAsync();

            return result;
        }

        public async Task LocationEdit(int id, LocationModel model)
        {
            var locEntity = await repository.GetByIdAsync<Location>(id);

            locEntity.Name = model.Name;
            locEntity.Address = model.Address;
            locEntity.Seats = model.Seats;
            locEntity.PlaceTypeId = model.PlaceTypeId;

            await repository.SaveChangesAsync();
        }

        public async Task LocationDelete(int id)
        {
            var locationEntity = await repository.GetByIdAsync<Location>(id);
            locationEntity.IsActive = false;
            await repository.SaveChangesAsync();
        }
    }
}
