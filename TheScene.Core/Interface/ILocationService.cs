using TheScene.Core.Models.Common;
using TheScene.Core.Models.Location;

namespace TheScene.Core.Interface
{
    public interface ILocationService
    {
        public Task<QueryModel<LocationModel>> AllLocationsInfo(
            string? placeType = null, string? searchTerm = null,
            int currentPage = 1, int locationPerPage = 10);

        public Task<int> CreateLocation(LocationModel model);

        public Task<LocationModel> LocationDetailsById(int id);

        public Task LocationEdit(int id, LocationModel model);

        public Task LocationDelete(int id);
    }
}
