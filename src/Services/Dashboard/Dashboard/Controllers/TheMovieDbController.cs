using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Api.TheMovieDb;
using Dashboard.Api.TheMovieDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class TheMovieDbController : Controller
    {
        private IMovieDbApi TmdbApi { get; }

        public TheMovieDbController(IMovieDbApi tmdbApi)
        {
            TmdbApi = tmdbApi;
        }

        /// <summary>
        /// Searches for keywords matching the specified term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        [HttpGet("Keyword")]
        public async Task<IActionResult> GetKeyword([FromQuery] string searchTerm)
        {
            var keyword = await TmdbApi.SearchKeyword(searchTerm);
            return keyword == null ? NotFound() : Ok(keyword);
        }
            

        /// <summary>
        /// Gets the keyword matching the specified ID.
        /// </summary>
        /// <param name="keywordId">The keyword ID.</param>
        [HttpGet("Keywords/{keywordId}")]
        public async Task<IActionResult> GetKeyword(int keywordId)
        {
            var keyword = await TmdbApi.GetKeyword(keywordId);
            return keyword == null ? NotFound() : Ok(keyword);
        }
    }
}