using System;

namespace Spotify.Client.Application.Boundaries.Library
{
    public interface IGetCurrentUsersSavedTracksOutputPort : IOkOutputPort<GetCurrentUsersSavedTracksOutput>,
                                                             IInternalServerErrorOutputPort<Exception> { }
}
