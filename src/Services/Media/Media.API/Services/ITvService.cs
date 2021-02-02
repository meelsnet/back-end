using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace Media.API.Services
{
    public interface ITvService
    {
        SearchContainer<SearchTv> SearchTv(string searchTerm);
        TvShow GetTv(int id);
    }
}