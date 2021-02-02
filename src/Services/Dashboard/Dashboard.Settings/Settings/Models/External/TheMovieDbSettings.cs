using System.Collections.Generic;

namespace Dashboard.Settings.Settings.Models.External
{
    public sealed class TheMovieDbSettings : Settings
    {
        public bool ShowAdultMovies { get; set; }
        public List<int> ExcludedKeywordIds { get; set; }
    }
}