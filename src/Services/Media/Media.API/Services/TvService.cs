using Microsoft.Extensions.Configuration;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace Media.API.Services
{
    public class TvService : ITvService
    {
        private readonly IConfiguration _config;
        private readonly TMDbClient _client;

        public TvService(IConfiguration config)
        {
            _config = config;
            _client = new TMDbClient(_config.GetValue<string>("TmdbApi:ApiKey"));
        }
        
        public SearchContainer<SearchTv> SearchTv(string searchTerm)
        {
            var results = _client.SearchTvShowAsync(searchTerm);
            return results.Result;
        }

        public TvShow GetTv(int id)
        {
            var results = _client.GetTvShowAsync(id);
            return results.Result;
        }
    }
}