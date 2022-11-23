using TheScene.Core.Models.GenreModels;

namespace TheScene.Core.Interface
{
    public interface IGenreService
    {
        public Task<IEnumerable<GenreModel>> AllGenres();

        public Task<IEnumerable<string>> AllGenresNames();

        public Task<bool> GenreExists(int genreId);
    }
}
