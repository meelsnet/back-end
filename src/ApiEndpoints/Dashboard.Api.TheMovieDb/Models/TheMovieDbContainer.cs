using System.Collections.Generic;

namespace Dashboard.Api.TheMovieDb.Models
{
    public class TheMovieDbContainer<T>
    {
        public int page { get; set; }
        public List<T> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}