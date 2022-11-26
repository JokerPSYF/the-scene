using Microsoft.EntityFrameworkCore;
using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Models.PerfomanceTypeModels;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class PerfomanceTypeService : IPerfomanceTypeService
    {
        private readonly IRepository repository;

        public PerfomanceTypeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PerfomanceTypeModel>> AllPerfomancesTypes()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .OrderBy(pt => pt.Name)
                .Select(pt => new PerfomanceTypeModel()
                {
                    Id = pt.Id,
                    Name = pt.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPErfomanceTypesNames()
        {
            return await repository.AllReadonly<PerfomanceType>()
                .Select(pt => pt.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> PerfomanceTypesExists(int perfomanceTypeId)
        {
            return await repository.AllReadonly<PerfomanceType>()
                .AnyAsync();
        }
    }
}
