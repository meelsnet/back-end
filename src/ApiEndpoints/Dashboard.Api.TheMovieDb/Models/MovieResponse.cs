using System;
using System.Collections.Generic;

namespace Dashboard.Api.TheMovieDb.Models
{
    public class MovieResponse
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public BelongsToCollection belongs_to_collection { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public ProductionCompanies[] production_companies { get; set; }
        public ProductionCountries[] production_countries { get; set; }
        public string release_date { get; set; }
        public float revenue { get; set; }
        public float runtime { get; set; }
        public SpokenLanguages[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public ReleaseDates release_dates { get; set; }
    }
    
    public class ReleaseDates
    {
        public List<ReleaseResults> results { get; set; }
    }

    public class ReleaseResults
    {
        public string iso_3166_1 { get; set; }
        public List<ReleaseDate> release_dates { get; set; }
    }

    public class ReleaseDate
    {
        public string Certification { get; set; }
        public string iso_639_1 { get; set; }
        public string note { get; set; }
        public DateTime release_date { get; set; }
        public int Type { get; set; }
    }
}