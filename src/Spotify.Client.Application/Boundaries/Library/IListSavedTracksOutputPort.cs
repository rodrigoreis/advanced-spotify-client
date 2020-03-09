using System;

namespace Spotify.Client.Application.Boundaries.Library
{
    public interface IListSavedTracksOutputPort : IOkOutputPort<ListSavedTracksOutput>,
                                                  IInternalServerErrorOutputPort<Exception> { }
}
