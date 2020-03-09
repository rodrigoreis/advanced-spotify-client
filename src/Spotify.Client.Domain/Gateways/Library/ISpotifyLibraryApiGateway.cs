using System.Threading.Tasks;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Domain.Gateways.Library
{
    public interface ISpotifyLibraryApiGateway
    {
        Task<ITrack[]> ListSavedTracksAsync(int limit, int offset);
    }
}
