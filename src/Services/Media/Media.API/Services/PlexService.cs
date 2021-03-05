using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Media.API.Models;
using Plex.Api;
using Plex.Api.Models;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;
using Directory = Plex.Api.Models.Directory;
using RestSharp;

namespace Media.API.Services
{
    public class PlexService : IPlexService
    {
        private readonly IPlexClient _plexClient;
        private readonly IMapper _mapper;

        public PlexService(IPlexClient plexClient, IMapper mapper)
        {
            _plexClient = plexClient;
            _mapper = mapper;
        }

        public async Task<List<Server>> GetServers(string authKey)
        {
            List<Server> servers = await _plexClient.GetServers(authKey);

            return servers;
        }

        public async Task<List<Session>> GetActiveSessions(string authKey, string plexServerHost)
        {
            List<Session> sessions = await _plexClient.GetSessions(authKey, plexServerHost);
            if (sessions == null || sessions.Count == 0)
            {
                return null;
            }

            return sessions;
        }

        public async Task<Session> GetActiveSessionForPlayer(string authKey, string plexServerHost, string playerMachineId)
        {
            List<Session> sessions = await _plexClient.GetSessions(authKey, plexServerHost);
            if (sessions == null || sessions.Count == 0)
            {
                return null;
            }

            return sessions.FirstOrDefault(c =>
                string.Equals(c.Player.MachineIdentifier, playerMachineId, StringComparison.OrdinalIgnoreCase));
        }
    }
}