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
        Task<SessionModel> GetActiveSession(string authKey, string plexServerHost, string playerMachineId);
        Task<List<Directory>> GetLibraries(string authKey, string plexServerHost);
        Task<MediaContainer> GetLibrary(string authKey, string plexServerHost, string libraryKey);
        Task<List<Metadata>> GetLibraryItems(string authKey, string plexServerHost, string libraryKey);
        Task<List<Server>> GetServers(string authKey);
        Task<List<Metadata>> GetRandomMovies(string authKey, string plexServerHost, string[] libraryKeys, int numberOfMovies = 1);
        Task<List<Session>> GetActiveSessions(string authKey, string plexServerHost);
        Task<Session> GetActiveSessionForPlayer(string authKey, string plexServerHost, string playerMachineId);
    }
}