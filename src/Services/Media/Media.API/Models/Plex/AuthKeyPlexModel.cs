using System.ComponentModel.DataAnnotations;

namespace Media.API.Models
{
    public class AuthKeyPlexModel
    {
        [Required]
        public string AuthKey { get; set; }
    }
}