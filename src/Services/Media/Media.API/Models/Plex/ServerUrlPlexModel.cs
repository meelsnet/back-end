using System.ComponentModel.DataAnnotations;

namespace Media.API.Models
{
    public class ServerUrlPlexModel : AuthKeyPlexModel
    {
        [Required] public string ServerUrl { get; set; }
    }
}