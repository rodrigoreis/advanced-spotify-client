using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Infrastructure.Gateways.Library
{
    internal class SpotifyLibraryApiGateway : ISpotifyLibraryApiGateway
    {
        public Task<IEnumerable<ITrack>> GetCurrentUsersSavedTracksAsync(string limit, int offset)
        {
            throw new System.NotImplementedException();
        }
    }
}
