using Microsoft.AspNetCore.Mvc;

namespace Media.API.Services
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _movies;

        public MovieController(IMoviesService movies)
        {
            _movies = movies;
        }

        /// <summary>
        /// Searches TMDB api movies based on searchTerm
        /// </summary>
        /// <param name="searchTerm">Used to look for movies based on your input</param>
        /// <returns>List of movies based on searchTerm</returns>
        [HttpGet("[action]/{searchTerm}")]
        public IActionResult SearchMovies(string searchTerm)
        {
            return Ok(_movies.SearchMovies(searchTerm));
        }

        /// <summary>
        /// Gets specific movie based on TmdbId
        /// </summary>
        /// <param name="id">Input for TmdbId</param>
        /// <returns>Gets movie based on given TmdbId</returns>
        [HttpGet("[action]/{id}")]
        public IActionResult GetMovie(int id)
        {
            return Ok(_movies.GetMovie(id));
        }
    }
}