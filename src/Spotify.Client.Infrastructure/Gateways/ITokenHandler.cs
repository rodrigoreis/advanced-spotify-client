using SpotifyAPI.Web.Models;

namespace Spotify.Client.Infrastructure.Gateways
{
    public interface ITokenHandler
    {
        Token Token { get; }
    }
}
