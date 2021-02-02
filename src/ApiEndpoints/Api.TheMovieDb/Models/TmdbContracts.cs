using System.Collections.Generic;

namespace Api.TheMovieDb.Models
{
	public class Images
	{
		public string BaseUrl { get; set; }
		public string SecureBaseUrl { get; set; }
		public List<string> BackdropSizes { get; set; }
		public List<string> LogoSizes { get; set; }
		public List<string> PosterSizes { get; set; }
		public List<string> profile_sizes { get; set; }
		public List<string> still_sizes { get; set; }
	}

	public class Configuration
	{
		public Images images { get; set; }
		public List<string> change_keys { get; set; }
	}

	public class Result
	{
		public bool Adult { get; set; }
		public string BackdropPath { get; set; }
		public int Id { get; set; }
		public string OriginalTitle { get; set; }
		public string ReleaseDate { get; set; }
		public string PosterPath { get; set; }
		public double Popularity { get; set; }
		public string Title { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}

	public class Movies
	{
		public int Page { get; set; }
		public List<TmdbMovie> Results { get; set; }
		public int TotalPages { get; set; }
		public int TotalResults { get; set; }
	}

	public class Genres
	{
		public List<Genre> Genre { get; set; }
	}

	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class ProductionCompany
	{
		public string Name { get; set; }
		public int id { get; set; }
	}

	public class ProductionCountry
	{
		public string iso_3166_1 { get; set; }
		public string name { get; set; }
	}

	public class SpokenLanguage
	{
		public string iso_639_1 { get; set; }
		public string name { get; set; }
	}

	public class TmdbMovie
	{
		public bool adult { get; set; }
		public string backdrop_path { get; set; }
		public object belongs_to_collection { get; set; }
		public int budget { get; set; }
		public List<string> genre_ids { get; set; }
		public string homepage { get; set; }
		public int id { get; set; }
		public string imdb_id { get; set; }
		public string original_title { get; set; }
		public string original_language { get; set; }
		public string overview { get; set; }
		public double popularity { get; set; }
		public string poster_path { get; set; }
		public List<ProductionCompany> production_companies { get; set; }
		public List<ProductionCountry> production_countries { get; set; }
		public string release_date { get; set; }
		public int revenue { get; set; }
		public int runtime { get; set; }
		public List<SpokenLanguage> spoken_languages { get; set; }
		public string status { get; set; }
		public string tagline { get; set; }
		public string title { get; set; }
		public double vote_average { get; set; }
		public int vote_count { get; set; }
	}
}