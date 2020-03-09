using System;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Domain.Gateways.Library
{
    public interface ILibraryEventHandler
    {
        public event EventHandler<ITrack[]> OnListSavedTracks;
        public event EventHandler<Exception> OnListSavedTracksError;
    }
}
