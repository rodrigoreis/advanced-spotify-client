using System.Threading.Tasks;

namespace Spotify.Client.Domain.Gateways.Library
{
    public interface ISpotifyLibraryApiGateway
    {
        Task ListSavedTracksAsync(int limit, int offset);
    }
}
