using System;
using System.Threading.Tasks;
using Spotify.Client.Domain.Gateways.Library;

namespace Spotify.Client.Infrastructure.Gateways.Library
{
    internal class SpotifyLibraryApiGateway : ISpotifyLibraryApiGateway
    {
        private readonly ISpotifyAuthenticator _spotifyAuthenticator;
        private readonly LibraryEventHandler _libraryEventHandler;

        public SpotifyLibraryApiGateway(ISpotifyAuthenticator spotifyAuthenticator,
                                        LibraryEventHandler libraryEventHandler)
        {
            _libraryEventHandler = libraryEventHandler;
            _spotifyAuthenticator = spotifyAuthenticator;
        }

        public Task ListSavedTracksAsync(int limit, int offset) =>
            _spotifyAuthenticator.AuthenticateAsync(api =>
            {
                try
                {
                    _libraryEventHandler.Invoke(api.GetSavedTracks(limit, offset));
                }
                catch (Exception ex)
                {
                    _libraryEventHandler.Error(ex);
                }
            });
    }
}
