using Microsoft.EntityFrameworkCore;
using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class PerfomanceTypeService : IPerfomanceTypeService
    {
        private readonly IRepository repository;

        private readonly IGuard guard;

        public PerfomanceTypeService(IRepository repository, IGuard guard)
        {
            this.repository = repository;
            this.guard = guard;
        }

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
