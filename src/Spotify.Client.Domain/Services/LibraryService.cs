using System;
using System.Threading.Tasks;
using Spotify.Client.Domain.Gateways.Library;

namespace Spotify.Client.Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ISpotifyLibraryApiGateway _spotifyLibraryApiGateway;

        public LibraryService(ISpotifyLibraryApiGateway spotifyLibraryApiGateway)
        {
            _spotifyLibraryApiGateway = spotifyLibraryApiGateway;
        }

        public Task ListSavedTracksAsync(int limit, int offset)
        {
            if (limit < 1 || limit > 50)
                throw new InvalidOperationException(
                    "Limit out of range. Minimum: 1. Maximum: 50.");

            return _spotifyLibraryApiGateway.ListSavedTracksAsync(limit, offset);
        }
    }
}
