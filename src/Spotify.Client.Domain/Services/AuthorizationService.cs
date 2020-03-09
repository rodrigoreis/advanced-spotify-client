using System.Threading.Tasks;
using Spotify.Client.Domain.Gateways.Authorization;

namespace Spotify.Client.Domain.Services
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationApiGateway _authorizationApiGateway;

        public AuthorizationService(IAuthorizationApiGateway authorizationApiGateway)
        {
            _authorizationApiGateway = authorizationApiGateway;
        }

        public Task AuthenticateAsync() => _authorizationApiGateway.AuthenticateAsync();
    }
}
