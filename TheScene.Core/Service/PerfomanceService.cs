using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Core.Models.PerfomanceModels;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class PerfomanceService : IPerfomanceService
    {
        private readonly IRepository repository;

        public PerfomanceService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<QueryModel<AllPerfomanceModel>> All(
            string? genre = null,
            string? perfomanceType = null,
            string? searchTerm = null,
            PerfomanceSotring sorting = PerfomanceSotring.Title,
            int currentPage = 1,
            int perfomancePerPage = 5)
        {
            var result = new QueryModel<AllPerfomanceModel>();

            var perfomances = repository.AllReadonly<Perfomance>()
                .Where(p => p.IsActive);

            if (!string.IsNullOrEmpty(genre))
            {
                perfomances = perfomances
                    .Where(p => p.Genre.Name == genre);
            }

            if (!string.IsNullOrEmpty(perfomanceType))
            {
                perfomances = perfomances
                    .Where(p => p.PerfomanceType.Name == perfomanceType);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                perfomances = perfomances
                    .Where(p =>
                    EF.Functions.Like(p.Title.ToLower(), searchTerm) ||
                   ((!string.IsNullOrEmpty(p.Director)) && EF.Functions.Like(p.Director.ToLower(), searchTerm)) ||
                    EF.Functions.Like(p.Genre.Name.ToLower(), searchTerm) ||
                    ((!string.IsNullOrEmpty(p.Actors)) && EF.Functions.Like(p.Actors.ToLower(), searchTerm)) ||
                    EF.Functions.Like(p.PerfomanceType.Name.ToLower(), searchTerm) ||
                   ((!string.IsNullOrEmpty(p.Description)) && EF.Functions.Like(p.Description.ToLower(), searchTerm)) ||
                    ((p.Year.HasValue) && EF.Functions.Like(p.Year.ToString()!, searchTerm)));
            }

            switch (sorting)
            {
                case PerfomanceSotring.PerfomanceType:
                    perfomances
                        .OrderBy(p => p.PerfomanceType.Name);
                    break;
                case PerfomanceSotring.Genre:
                    perfomances
                        .OrderBy(p => p.Genre.Name);
                    break;
                case PerfomanceSotring.Title:
                default:
                    perfomances
                        .OrderBy(p => p.Title);
                    break;
            }

            result.Collection = await perfomances
                .Skip((currentPage - 1) * perfomancePerPage)
                .Take(perfomancePerPage)
                .Select(p => new AllPerfomanceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Director = p.Director,
                    Genre = p.Genre.Name,
                    Actors = p.Actors,
                    PefomanceType = p.PerfomanceType.Name,
                    Year = p.Year,
                    ImageUrl = p.ImageURL
                })
                .ToListAsync();

            result.TotalCount = await perfomances.CountAsync();

            return result;
        }

        public async Task<int> Create(AddPerfomanceModel model)
        {
            var perfomance = new Perfomance()
            {
                Title = model.Title,
                Director = model.Director,
                GenreId = model.GenreId,
                Actors = model.Actors,
                PerfomanceTypeId = model.PerfomanceTypeId,
                Year = model.Year,
                ImageURL = model.ImageURL
            };

            await repository.AddAsync<Perfomance>(perfomance);
            await repository.SaveChangesAsync();

            return perfomance.Id;
        }

        public async Task Delete(int eventId)
        {
            var perfomance = await repository.GetByIdAsync<Perfomance>(eventId);
            perfomance.IsActive = false;

            await repository.SaveChangesAsync();
        }

        public async Task<DetailPerfomanceModel> DetailsById(int eventId)
        {
            return await repository.AllReadonly<Perfomance>()
                .Where(p => p.Id == eventId && p.IsActive)
                .Select(p => new DetailPerfomanceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Director = p.Director,
                    GenreId = p.Genre.Id,
                    Genre = p.Genre.Name,
                    Actors = p.Actors,
                    PerfomanceTypeId = p.PerfomanceType.Id,
                    PerfomanceType = p.PerfomanceType.Name,
                    Year = p.Year,
                    ImageURL = p.ImageURL,
                    Description = p.Description,
                })
                .FirstAsync();
        }

        public async Task Edit(int eventId, EditPerfomanceModel model)
        {
            var perfomance = await repository.GetByIdAsync<Perfomance>(eventId);

            perfomance.Title = model.Title;
            perfomance.Director = model.Director;
            perfomance.GenreId = model.GenreId;
            perfomance.Actors = model.Actors;
            perfomance.PerfomanceTypeId = model.PerfomanceTypeId;
            perfomance.Description = model.Description;
            perfomance.Year = model.Year;
            perfomance.ImageURL = model.ImageURL;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(int eventId)
        {
            return await repository.AllReadonly<Perfomance>()
                .AnyAsync(p => p.IsActive && p.Id == eventId);
        }
    }
}
