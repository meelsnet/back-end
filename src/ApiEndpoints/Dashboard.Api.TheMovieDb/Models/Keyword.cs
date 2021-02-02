using System.Runtime.Serialization;

namespace Dashboard.Api.TheMovieDb.Models
{
    public class Keyword
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}