using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Media.API.Services
{
    public interface IMoviesService
    {
        SearchContainer<SearchMovie> SearchMovies(string searchTerm);
        Movie GetMovie(int id);
    }
}