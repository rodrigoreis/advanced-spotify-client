using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Infrastructure.Gateways.Library;

namespace Spotify.Client.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISpotifyLibraryApiGateway, SpotifyLibraryApiGateway>();
            return services;
        }
    }
}
