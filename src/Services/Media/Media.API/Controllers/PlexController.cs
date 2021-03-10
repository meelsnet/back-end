using Media.API.Models;
using Microsoft.AspNetCore.Mvc;
using Plex.Api;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Media.API.Services
{
    [ApiController]
    [Route("[controller]")]
    public class PlexController : ControllerBase
    {
        private readonly IPlexClient _plexClient;
        private readonly IPlexService _plexService;

        public PlexController(IPlexClient plexClient, IPlexService plexService)
        {
            _plexClient = plexClient;
            _plexService = plexService;
        }

        /// <summary>
        /// Authenticate via Plex account
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Plex account info</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                return BadRequest(new { message = "Username is missing" });
            if (string.IsNullOrEmpty(model.Password))
                return BadRequest(new { message = "Password is missing" });

            var user = await _plexClient.SignIn(model.Username, model.Password);
            return Ok(user);
        }

        /// <summary>
        /// Find registered servers on plex account
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of registered plex servers</returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetServers([FromQuery] AuthKeyPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey))
                return BadRequest(new { message = "Auth key is null or empty" });

            var servers = await _plexService.GetServers(model.AuthKey);

            return Ok(servers);
        }

        /// <summary>
        /// Get active sessions
        /// </summary>
        /// <param name="authKey">Plex account authentication token</param>
        /// <param name="plexServerUrl">Plex servers fullUri</param>
        /// <param name="playerMachineId">Plex servers machineIdentifier</param>
        /// <returns>List of active sessions on specified plex server</returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSessions([Required] string authKey, [Required] string plexServerUrl, string playerMachineId)
        {
            if (string.IsNullOrEmpty(authKey) || string.IsNullOrEmpty(plexServerUrl))
                return BadRequest(new {message = "Auth key and/or server url is null or empty"});

            if (string.IsNullOrEmpty(playerMachineId))
                return Ok(await _plexService.GetActiveSessionForPlayer(authKey, plexServerUrl,
                    playerMachineId));

            return Ok(await _plexService.GetActiveSessions(authKey, plexServerUrl));
        }
    }
}