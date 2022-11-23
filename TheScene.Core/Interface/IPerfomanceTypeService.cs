using TheScene.Core.Models.Common;

namespace TheScene.Core.Interface
{
    public interface IPerfomanceTypeService
    {
        public Task<IEnumerable<NomenclatureDTO<int>>> AllPerfomancesTypes();

        public Task<IEnumerable<string>> AllPErfomanceTypesNames();

        public Task<bool> PerfomanceTypesExists(int perfomanceTypeId);
    }
}
