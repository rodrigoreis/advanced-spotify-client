using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Spotify.Client.Infrastructure.Gateways
{
    internal interface ISpotifyAuthenticator
    {
        Task AuthenticateAsync(Action<SpotifyWebAPI> callback);
    }
}
