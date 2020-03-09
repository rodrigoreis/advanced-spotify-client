using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Domain.Models;
using SpotifyAPI.Web;

namespace Spotify.Client.Infrastructure.Gateways.Library
{
    internal class SpotifyLibraryApiGateway : ISpotifyLibraryApiGateway
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;

        public SpotifyLibraryApiGateway(ITokenHandler tokenHandler, IMapper mapper)
        {
            _tokenHandler = tokenHandler;
            _mapper = mapper;
        }

        public Task<ITrack[]> ListSavedTracksAsync(int limit, int offset)
        {
            var api = new SpotifyWebAPI
            {
                TokenType = _tokenHandler.Token.TokenType,
                AccessToken = _tokenHandler.Token.AccessToken
            };
            var result = api.GetSavedTracks(limit, offset);
            return Task.FromResult(_mapper.Map<ITrack[]>(result).ToArray());
        }
    }
}
