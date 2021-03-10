using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.API.Models;
using Plex.Api.Models;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;
using Directory = Plex.Api.Models.Directory;

namespace Media.API.Services
{
    public interface IPlexService
    {
        Task<List<Server>> GetServers(string authKey);
        Task<List<Session>> GetActiveSessions(string authKey, string plexServerHost);
        Task<Session> GetActiveSessionForPlayer(string authKey, string plexServerHost, string playerMachineId);
    }
}