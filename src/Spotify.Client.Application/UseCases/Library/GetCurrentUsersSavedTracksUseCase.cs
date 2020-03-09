using System;
using System.Threading.Tasks;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Domain.Services;

namespace Spotify.Client.Application.UseCases.Library
{
    internal class GetCurrentUsersSavedTracksUseCase : IGetCurrentUsersSavedTracksUseCase
    {
        private readonly ILibraryService _libraryService;
        private readonly IGetCurrentUsersSavedTracksOutputPort _getCurrentUsersSavedTracksOutputPort;

        public GetCurrentUsersSavedTracksUseCase(ILibraryService libraryService,
                                                 IGetCurrentUsersSavedTracksOutputPort
                                                     getCurrentUsersSavedTracksOutputPort)
        {
            _libraryService = libraryService;
            _getCurrentUsersSavedTracksOutputPort = getCurrentUsersSavedTracksOutputPort;
        }

        public Task ExecuteAsync(GetCurrentUsersSavedTracksInput input)
        {
            return _libraryService
                   .GetCurrentUsersSavedTracksAsync(input.Limit, input.Offset)
                   .ContinueWith(t =>
                   {
                       _getCurrentUsersSavedTracksOutputPort.Ok(
                           new GetCurrentUsersSavedTracksOutput(t.Result));
                   }, TaskContinuationOptions.OnlyOnRanToCompletion)
                   .ContinueWith(
                       t => _getCurrentUsersSavedTracksOutputPort.InternalServerError(new Exception(
                           "task was canceled.")),
                       TaskContinuationOptions.OnlyOnCanceled)
                   .ContinueWith(
                       t => _getCurrentUsersSavedTracksOutputPort.InternalServerError(t.Exception),
                       TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
