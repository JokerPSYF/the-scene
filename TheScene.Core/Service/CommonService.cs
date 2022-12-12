using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    /// <summary>
    /// Get all all common things like genres, perfomances, perfoamnesType etc.
    /// </summary>
    public class CommonService : ICommonService
    {
        private readonly IRepository repository;

        public CommonService(IRepository _repository)
        {
            this.repository = _repository;
        }

        #region Genre
        /// <summary>
        /// All Genres ids and names
        /// </summary>
        /// <returns>IEnumerable of NomenclatureDTO</returns>
        public async Task<IEnumerable<NomenclatureDTO>> AllGenres()
        {
            return await repository.AllReadonly<Genre>()
                .OrderBy(g => g.Name)
                .Select(g => new NomenclatureDTO()
                {
                    Id = g.Id,
                    DisplayName = g.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// All Genre by their names
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public async Task<IEnumerable<string>> AllGenresNames()
        {
            return await repository.AllReadonly<Genre>()
                .Select(g => g.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Check if that genre exissts
        /// </summary>
        /// <param name="genreId">genre id (int)</param>
        /// <returns>bool</returns>
        public async Task<bool> GenreExists(int genreId)
        {
            return await repository.AllReadonly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }
        #endregion

        #region Location
        /// <summary>
        /// All location ids and name
        /// </summary>
        /// <returns>IEnumerable of NomenclatureDTO</returns>
        public async Task<IEnumerable<NomenclatureDTO>> AllLocations()
        {
            return await repository.AllReadonly<Location>()
                .OrderBy(l => l.Name)
                .Select(l => new NomenclatureDTO()
                {
                    Id = l.Id,
                    DisplayName = l.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// All locations name
        /// </summary>
        /// <returns>IEnumerable of string</returns>
        public async Task<IEnumerable<string>> AllLocationsNames()
        {
            return await repository.AllReadonly<Location>()
                .Select(l => l.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Check if that location exists
        /// </summary>
        /// <param name="locationbId">location id (int)</param>
        /// <returns>bool</returns>
        public async Task<bool> LocationExists(int locationbId)
        {
            return await repository.AllReadonly<Location>()
                .AnyAsync(l => l.Id == locationbId);
        }
        #endregion

        #region Perfomance

        /// <summary>
        /// All perfomances id's and names 
        /// </summary>
        /// <returns>IEnumerable of NomenclatureDTO</returns>
        public async Task<IEnumerable<NomenclatureDTO>> AllPerfomances()
        {
            return await repository.AllReadonly<Perfomance>()
                .OrderBy(p => p.Title)
                .Select(p => new NomenclatureDTO()
                {
                    Id = p.Id,
                    DisplayName = p.Title
                })
                .ToListAsync();
        }

        /// <summary>
        /// All perfomances names
        /// </summary>
        /// <returns>IEnumerable of string</returns>
        public async Task<IEnumerable<string>> AllPerfomancesNames()
        {
            return await repository.AllReadonly<Perfomance>()
                .Select(p => p.Title)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Check if that perfomance exists
        /// </summary>
        /// <param name="perfomanceId">perfomance id (int)</param>
        /// <returns>bool</returns>
        public async Task<bool> PerfomancesExists(int perfomanceId)
        {
            return await repository.AllReadonly<Perfomance>()
               .AnyAsync(p => p.Id == perfomanceId);
        }
        #endregion

        #region Perfomance Type

        /// <summary>
        /// All perfomances types id's and names
        /// </summary>
        /// <returns>IEnumerable of NomenclatureDTO</returns>
        public async Task<IEnumerable<NomenclatureDTO>> AllPerfomancesTypes()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .OrderBy(pt => pt.Name)
                .Select(pt => new NomenclatureDTO()
                {
                    Id = pt.Id,
                    DisplayName = pt.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// All perfomances types names
        /// </summary>
        /// <returns>IEnumerable of string</returns>
        public async Task<IEnumerable<string>> AllPerfomanceTypesNames()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .Select(pt => pt.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Check if perfomance type exists
        /// </summary>
        /// <param name="perfomanceTypeId">perfomance type id (int)</param>
        /// <returns>bool</returns>
        public async Task<bool> PerfomanceTypesExists(int perfomanceTypeId)
        {
            return await repository.AllReadonly<PerfomanceType>()
                .AnyAsync(pt => pt.Id == perfomanceTypeId);
        }
        #endregion

        #region Place type

        /// <summary>
        /// All place types id and names
        /// </summary>
        /// <returns>IEnumerable of NomenclatureDTO</returns>
        public async Task<IEnumerable<NomenclatureDTO>> AllPlaceTypes()
        {
            return await repository.AllReadonly<PlaceType>()
                .OrderBy(l => l.Name)
                .Select(l => new NomenclatureDTO()
                {
                    Id = l.Id,
                    DisplayName = l.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// All place types names
        /// </summary>
        /// <returns>IEnumerable of string</returns>
        public async Task<IEnumerable<string>> AllPlaceTypesNames()
        {
            return await repository.AllReadonly<PlaceType>()
                .Select(l => l.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Check if place type exists
        /// </summary>
        /// <param name="placeTypeId">place type id (int)</param>
        /// <returns>bool</returns>
        public async Task<bool> PlaceTypeExists(int placeTypeId)
        {
            return await repository.AllReadonly<PlaceType>()
                .AnyAsync(l => l.Id == placeTypeId);
        }
        #endregion
    }
}