using Microsoft.AspNetCore.Mvc;

namespace Media.API.Services
{
    [ApiController]
    [Route("[controller]")]
    public class TvController : ControllerBase
    {
        private readonly ITvService _tv;

        public TvController(ITvService tv)
        {
            _tv = tv;
        }

        /// <summary>
        /// Searches TMDB api tv show based on searchTerm
        /// </summary>
        /// <param name="searchTerm">Used to look for tv show based on your input</param>
        /// <returns>List of tv shows based on searchTerm</returns>
        [HttpGet("[action]/{searchTerm}")]
        public IActionResult SearchTv(string searchTerm)
        {
            return Ok(_tv.SearchTv(searchTerm));
        }

        /// <summary>
        /// Gets specific tv show based on TmdbId
        /// </summary>
        /// <param name="id">Input for TmdbId</param>
        /// <returns>Gets tv show based on given TmdbId</returns>
        [HttpGet("[action]/{id}")]
        public IActionResult GetTv(int id)
        {
            return Ok(_tv.GetTv(id));
        }
    }
}