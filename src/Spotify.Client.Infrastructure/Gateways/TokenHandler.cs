using SpotifyAPI.Web.Models;

namespace Spotify.Client.Infrastructure.Gateways
{
    internal class TokenHandler : ITokenHandler
    {
        public Token Token { get; set; }
    }
}
