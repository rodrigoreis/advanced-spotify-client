using System;
using System.Threading.Tasks;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Domain.Services;

namespace Spotify.Client.Application.UseCases.Library
{
    internal class ListSavedTracksUseCase : IListSavedTracksUseCase
    {
        private readonly ILibraryService _libraryService;
        private readonly IListSavedTracksOutputPort _listSavedTracksOutputPort;
        private readonly ILibraryEventHandler _libraryEventHandler;

        public ListSavedTracksUseCase(ILibraryService libraryService,
                                      IListSavedTracksOutputPort listSavedTracksOutputPort,
                                      ILibraryEventHandler libraryEventHandler)
        {
            _libraryService = libraryService;
            _listSavedTracksOutputPort = listSavedTracksOutputPort;
            _libraryEventHandler = libraryEventHandler;
        }

        public Task ExecuteAsync(ListSavedTracksInput input)
        {
            _libraryEventHandler.OnListSavedTracks += (_, tracks) =>
            {
                _listSavedTracksOutputPort.Ok(new ListSavedTracksOutput(tracks));
            };

            _libraryEventHandler.OnListSavedTracksError += (_, ex) =>
            {
                _listSavedTracksOutputPort.InternalServerError(ex);
            };

            return _libraryService.ListSavedTracksAsync(input.Limit, input.Offset);
        }
    }
}
