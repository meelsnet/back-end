using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Authentication.API.Models
{
    public class AuthenticationModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}