using TheScene.Core.Models.Common;

namespace TheScene.Core.Interface
{
    public interface ICommonService
    {
        #region Genre
        public Task<IEnumerable<NomenclatureDTO<int>>> AllGenres();

        public Task<IEnumerable<string>> AllGenresNames();

        public Task<bool> GenreExists(int genreId);
        #endregion

        #region Location
        public Task<IEnumerable<NomenclatureDTO<int>>> AllLocations();

        public Task<IEnumerable<string>> AllLocationsNames();

        public Task<bool> LocationExists(int locationId);
        #endregion
  
        #region Perfomance
        public Task<IEnumerable<NomenclatureDTO<int>>> AllPerfomances();

        public Task<IEnumerable<string>> AllPerfomancesNames();

        public Task<bool> PerfomancesExists(int perfomanceId);
        #endregion

        #region Perfomance Type
        public Task<IEnumerable<NomenclatureDTO<int>>> AllPerfomancesTypes();

        public Task<IEnumerable<string>> AllPerfomanceTypesNames();

        public Task<bool> PerfomanceTypesExists(int perfomanceTypeId);
        #endregion
    }
}