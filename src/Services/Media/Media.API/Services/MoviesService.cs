using Microsoft.Extensions.Configuration;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Media.API.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly TMDbClient _client;

        public MoviesService(IConfiguration config)
        {
            _client = new TMDbClient(config.GetValue<string>("TmdbApi:ApiKey"));
        }

        public SearchContainer<SearchMovie> SearchMovies(string searchTerm)
        {
            var results = _client.SearchMovieAsync(searchTerm);
            return results.Result;
        }


        public Movie GetMovie(int id)
        {
            var results = _client.GetMovieAsync(id);
            return results.Result;
        }
    }
}