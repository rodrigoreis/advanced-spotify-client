using System.Collections.Generic;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Application.Boundaries.Library
{
    public class ListSavedTracksOutput
    {
        public IEnumerable<ITrack> Tracks { get; }

        private ListSavedTracksOutput() { }

        public ListSavedTracksOutput(IEnumerable<ITrack> tracks) : this()
        {
            Tracks = tracks;
        }
    }
}
