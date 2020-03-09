using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Ui.Presenters.Library;

namespace Spotify.Client.Ui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpotifyClientMediatorPipelines(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder
                        .On<ListSavedTracksInput>()
                        .PipelineAsync()
                        .Call<IListSavedTracksUseCase>(
                            (useCase, input) => useCase.ExecuteAsync(input));
                }
            );

            return services;
        }

        public static IServiceCollection AddSpotifyClientPresenters(this IServiceCollection services)
        {
            services.AddScoped<ListSavedTracksPresenter>();
            services.AddScoped<IListSavedTracksOutputPort>(provider =>
                provider.GetRequiredService<ListSavedTracksPresenter>());

            return services;
        }
    }
}
