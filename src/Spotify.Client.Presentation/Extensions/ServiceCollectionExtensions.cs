using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Presentation.Presenters.Library;

namespace Spotify.Client.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpotifyClientMediatorPipelines(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder
                        .On<GetCurrentUsersSavedTracksInput>()
                        .PipelineAsync()
                        .Call<IGetCurrentUsersSavedTracksUseCase>(
                            (useCase, input) => useCase.ExecuteAsync(input));
                }
            );

            return services;
        }

        public static IServiceCollection AddSpotifyClientPresenters(this IServiceCollection services)
        {
            services.AddScoped<GetCurrentUsersSavedTracksPresenter>();
            services.AddScoped<IGetCurrentUsersSavedTracksOutputPort>(provider =>
                provider.GetRequiredService<GetCurrentUsersSavedTracksPresenter>());

            return services;
        }
    }
}
