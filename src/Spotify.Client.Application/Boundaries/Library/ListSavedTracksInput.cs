namespace Spotify.Client.Application.Boundaries.Library
{
    public class ListSavedTracksInput
    {
        public int Limit { get; }
        public int Offset { get; }

        private ListSavedTracksInput() { }

        public ListSavedTracksInput(int limit, int offset) : this()
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
