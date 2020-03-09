using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Infrastructure.Gateways;
using Spotify.Client.Infrastructure.Gateways.Library;

namespace Spotify.Client.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string AppDomainNamespace = "Spotify.Client";

        public static IServiceCollection AddSpotifyAuthentication(this IServiceCollection services)
        {
            services.AddOptions<SpotifyCredentials>()
                    .Configure<IConfiguration>((options, configurationHandler) =>
                    {
                        configurationHandler
                            .GetSection(nameof(SpotifyCredentials))
                            .Bind(options);
                    });

            services.AddScoped<ISpotifyAuthenticator, SpotifyAuthenticator>();

            return services;
        }

        private static IServiceCollection AddTypeMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                (provider, cfg) =>
                {
                    cfg.AddExpressionMapping();
                    cfg.ConstructServicesUsing(
                        type => ActivatorUtilities.CreateInstance(provider, type)
                    );
                },
                AppDomain.CurrentDomain
                         .GetAssemblies()
                         .Where(a => a.FullName.StartsWith(AppDomainNamespace))
            );

            return services;
        }

        private static IServiceCollection AddGatewayEvents(this IServiceCollection services)
        {
            services.AddScoped<LibraryEventHandler>();
            services.AddScoped<ILibraryEventHandler, LibraryEventHandler>(provider =>
                provider.GetRequiredService<LibraryEventHandler>());

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTypeMapping();
            services.AddGatewayEvents();
            services.AddScoped<ISpotifyLibraryApiGateway, SpotifyLibraryApiGateway>();
            return services;
        }
    }
}
