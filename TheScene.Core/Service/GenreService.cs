using Microsoft.EntityFrameworkCore;
using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Models.GenreModels;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class GenreService : IGenreService
    {
        private readonly IRepository repository;

        private readonly IGuard guard;

        public GenreService(IRepository repository, IGuard guard)
        {
            this.repository = repository;
            this.guard = guard;
        }

        public async Task<IEnumerable<GenreModel>> AllGenres()
        {
            return await repository.AllReadonly<Genre>()
                .OrderBy(g => g.Name)
                .Select(g => new GenreModel()
                {
                    Id = g.Id,
                    Name = g.Name
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
                .AnyAsync();
        }
    }
}
