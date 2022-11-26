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
        public async Task<IEnumerable<NomenclatureDTO<int>>> AllGenres()
        {
            return await repository.AllReadonly<Genre>()
                .OrderBy(g => g.Name)
                .Select(g => new NomenclatureDTO<int>()
                {
                    Value = g.Id,
                    DisplayName = g.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllGenresNames()
        {
            return await repository.AllReadonly<Genre>()
                .Select(g => g.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> GenreExists(int genreId)
        {
            return await repository.AllReadonly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }
        #endregion

        #region Location
        public async Task<IEnumerable<NomenclatureDTO<int>>> AllLocations()
        {
            return await repository.AllReadonly<Location>()
                .OrderBy(l => l.Name)
                .Select(l => new NomenclatureDTO<int>()
                {
                    Value = l.Id,
                    DisplayName = l.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllLocationsNames()
        {
            return await repository.AllReadonly<Location>()
                .Select(l => l.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> LocationExists(int locationbId)
        {
            return await repository.AllReadonly<Location>()
                .AnyAsync(l => l.Id == locationbId);
        }
        #endregion

        #region Perfomance
        public async Task<IEnumerable<NomenclatureDTO<int>>> AllPerfomances()
        {
            return await repository.AllReadonly<Perfomance>()
                .OrderBy(p => p.Title)
                .Select(p => new NomenclatureDTO<int>()
                {
                    Value = p.Id,
                    DisplayName = p.Title
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPerfomancesNames()
        {
            return await repository.AllReadonly<Perfomance>()
                .Select(p => p.Title)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> PerfomancesExists(int perfomanceId)
        {
            return await repository.AllReadonly<Perfomance>()
               .AnyAsync(p => p.Id == perfomanceId);
        }
        #endregion

        #region Perfomance Type
        public async Task<IEnumerable<NomenclatureDTO<int>>> AllPerfomancesTypes()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .OrderBy(pt => pt.Name)
                .Select(pt => new NomenclatureDTO<int>()
                {
                    Value = pt.Id,
                    DisplayName = pt.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPerfomanceTypesNames()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .Select(pt => pt.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> PerfomanceTypesExists(int perfomanceTypeId)
        {
            return await repository.AllReadonly<PerfomanceType>()
                .AnyAsync(pt => pt.Id == perfomanceTypeId);
        }
        #endregion
    }
}