using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Application.Boundaries.Authorization;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Application.UseCases.Authorization;
using Spotify.Client.Application.UseCases.Library;

namespace Spotify.Client.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();
            services.AddScoped<IListSavedTracksUseCase, ListSavedTracksUseCase>();
            return services;
        }
    }
}
