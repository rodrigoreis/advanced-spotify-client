using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;

namespace Spotify.Client.Infrastructure.Gateways
{
    public class SpotifyAuthenticator : ISpotifyAuthenticator
    {
        private readonly SpotifyCredentials _spotifyCredentials;

        public SpotifyAuthenticator(IOptions<SpotifyCredentials> spotifyCredentialsOptions)
        {
            _spotifyCredentials = spotifyCredentialsOptions.Value;
        }

        public Task AuthenticateAsync(Action<SpotifyWebAPI> callback)
        {
            var auth = new ImplicitGrantAuth(_spotifyCredentials.ClientId, _spotifyCredentials.RedirectUri,
                _spotifyCredentials.ServerUri, Scope.UserReadPrivate);

            auth.AuthReceived += (sender, payload) => 
            {
                auth.Stop();

                var api = new SpotifyWebAPI()
                {
                    TokenType = payload.TokenType,
                    AccessToken = payload.AccessToken
                };

                callback(api);
            };

            auth.Start();
            auth.OpenBrowser();

            return Task.CompletedTask;
        }
    }
}
