using System.Threading.Tasks;
using Spotify.Client.Application.Boundaries.Authorization;
using Spotify.Client.Domain.Services;

namespace Spotify.Client.Application.UseCases.Authorization
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthenticateUseCase(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public Task ExecuteAsync() => _authorizationService.AuthenticateAsync();
    }
}
