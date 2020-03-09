using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Spotify.Client.Domain.Gateways.Authorization;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;

namespace Spotify.Client.Infrastructure.Gateways.Authorization
{
    internal class AuthorizationApiGateway : IAuthorizationApiGateway
    {
        private readonly SpotifyCredentials _spotifyCredentials;
        private readonly TokenHandler _tokenHandler;

        public AuthorizationApiGateway(IOptions<SpotifyCredentials> options, TokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _spotifyCredentials = options.Value;
        }

        public Task AuthenticateAsync()
        {
            var auth = new AuthorizationCodeAuth(
                _spotifyCredentials.ClientId,
                _spotifyCredentials.ClientSecret,
                _spotifyCredentials.RedirectUri,
                _spotifyCredentials.ServerUri,
                Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative
            );

            auth.AuthReceived += async (sender, payload) =>
            {
                auth.Stop();
                _tokenHandler.Token = await auth.ExchangeCode(payload.Code);
            };

            auth.Start();
            auth.OpenBrowser();

            return Task.CompletedTask;
        }
    }
}
