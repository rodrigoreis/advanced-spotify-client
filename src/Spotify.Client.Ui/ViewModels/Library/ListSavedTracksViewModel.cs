using Spotify.Client.Ui.Models;

namespace Spotify.Client.Ui.ViewModels.Library
{
    public class ListSavedTracksViewModel
    {
        public Track[] Tracks { get; }

        private ListSavedTracksViewModel() { }

        public ListSavedTracksViewModel(Track[] tracks) : this()
        {
            Tracks = tracks;
        }
    }
}
