using System.ComponentModel.DataAnnotations;

namespace Media.API.Models
{
    public class ServerKeyPlexModel : AuthKeyPlexModel
    {
        [Required] public string ServerKey { get; set; }
        
    }
}