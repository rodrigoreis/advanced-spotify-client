using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Domain.Gateways.Library
{
    public interface ISpotifyLibraryApiGateway
    {
        Task<IEnumerable<ITrack>> GetCurrentUsersSavedTracksAsync(string limit, int offset);
    }
}
