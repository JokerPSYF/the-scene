﻿using Microsoft.EntityFrameworkCore;
using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class GenreService : IGenreService
    {
        private readonly IRepository repository;

        public GenreService(IRepository repository)
        {
            this.repository = repository;
        }

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
                .AnyAsync();
        }
    }
}
