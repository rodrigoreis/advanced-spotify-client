using System.Collections.Generic;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Application.Boundaries.Library
{
    public class GetCurrentUsersSavedTracksOutput
    {
        private IEnumerable<ITrack> Tracks { get; }

        private GetCurrentUsersSavedTracksOutput() { }

        public GetCurrentUsersSavedTracksOutput(IEnumerable<ITrack> tracks) : this()
        {
            Tracks = tracks;
        }
    }
}
