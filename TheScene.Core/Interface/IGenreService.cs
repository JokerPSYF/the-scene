using TheScene.Core.Models.Common;

namespace TheScene.Core.Interface
{
    public interface IGenreService
    {
        public Task<IEnumerable<NomenclatureDTO<int>>> AllGenres();

        public Task<IEnumerable<string>> AllGenresNames();

        public Task<bool> GenreExists(int genreId);
    }
}
