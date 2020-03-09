using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Domain.Services;

namespace Spotify.Client.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}
