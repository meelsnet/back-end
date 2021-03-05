using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Media.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plex.Api;
using Plex.Api.Models;

namespace Media.API.Services
{
    [ApiController]
    [Route("[controller]")]
    public class PlexController : ControllerBase
    {
        private readonly IPlexClient _plexClient;
        private readonly IPlexService _plexService;
        private readonly ILogger<PlexController> _logger;

        public PlexController(IPlexClient plexClient, IPlexService plexService)
        {
            _plexClient = plexClient;
            _plexService = plexService;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                return BadRequest(new { message = "Username is missing" });
            if (string.IsNullOrEmpty(model.Password))
                return BadRequest(new { message = "Password is missing" });

            var user = await _plexClient.SignIn(model.Username, model.Password);
            return Ok(user);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLibraryMetadata([FromRoute] GetLibraryPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey) || string.IsNullOrEmpty(model.ServerUrl) || string.IsNullOrEmpty(model.LibraryKey))
                return BadRequest(new {message = "The required fields are not filled in correctly"});

            List<Metadata> items = await _plexService.GetLibraryItems(model.AuthKey, model.ServerUrl, model.LibraryKey);

            return Ok(items);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLibrary([FromRoute] GetLibraryPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey) || string.IsNullOrEmpty(model.ServerUrl) ||
                string.IsNullOrEmpty(model.LibraryKey))
                return BadRequest(new { message = "The required fields are not filled in correctly" });

            MediaContainer library = await _plexService.GetLibrary(model.AuthKey, model.ServerUrl, model.LibraryKey);

            if (library == null)
                return NotFound();

            return Ok(library);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLibraries([FromRoute] GetLibrariesPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey) || string.IsNullOrEmpty(model.ServerUrl))
                return BadRequest(new { message = "The required fields are not filled in correctly" });

            List<Directory> libraries = await _plexService.GetLibraries(model.AuthKey, model.ServerUrl);

            if(model.LibraryKeys.Any())
                libraries = libraries.Where(c => model.LibraryKeys.Contains(c.Key)).ToList();
            if (model.Types.Any())
                libraries = libraries.Where(c => model.Types.Contains(c.Type, StringComparer.OrdinalIgnoreCase)).ToList();
            if (model.Titles.Any())
                libraries = libraries.Where(c => model.Titles.Contains(c.Title, StringComparer.OrdinalIgnoreCase)).ToList();

            return Ok(libraries);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServers([FromQuery] AuthKeyPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey))
                return BadRequest(new { message = "Auth key is null or empty" });

            var servers = await _plexService.GetServers(model.AuthKey);

            return Ok(servers);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServer([FromQuery] ServerKeyPlexModel model)
        {
            if (string.IsNullOrEmpty(model.AuthKey))
                return BadRequest(new {message = "Auth key is null or empty"});

            if (string.IsNullOrEmpty(model.ServerKey))
                return BadRequest(new {message = "Server key is null or empty"});

            var servers = await _plexClient.GetServers(model.AuthKey);
            
            return Ok(servers?.SingleOrDefault(c =>
                    string.Equals(c.MachineIdentifier, model.ServerKey, StringComparison.OrdinalIgnoreCase)));
        }

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

        [HttpPost("[action]")]
        public void GetWebhook([FromBody] PayloadPlexModel model)
        {
            _logger.LogInformation("GetWebhook response captures from");
        }
    }
}