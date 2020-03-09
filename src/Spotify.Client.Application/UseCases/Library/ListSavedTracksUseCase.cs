using System;
using System.Threading.Tasks;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Domain.Services;

namespace Spotify.Client.Application.UseCases.Library
{
    internal class ListSavedTracksUseCase : IListSavedTracksUseCase
    {
        private readonly ILibraryService _libraryService;
        private readonly IListSavedTracksOutputPort _listSavedTracksOutputPort;

        public ListSavedTracksUseCase(ILibraryService libraryService,
                                      IListSavedTracksOutputPort listSavedTracksOutputPort)
        {
            _libraryService = libraryService;
            _listSavedTracksOutputPort = listSavedTracksOutputPort;
        }

        public async Task ExecuteAsync(ListSavedTracksInput input)
        {
            try
            {
                var result = await _libraryService.ListSavedTracksAsync(input.Limit, input.Offset);
                _listSavedTracksOutputPort.Ok(new ListSavedTracksOutput(result));
            }
            catch (Exception ex)
            {
                _listSavedTracksOutputPort.InternalServerError(ex);
            }
        }
    }
}
