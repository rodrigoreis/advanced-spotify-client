namespace Spotify.Client.Application.Boundaries.Library
{
    public class GetCurrentUsersSavedTracksInput
    {
        public int Limit { get; }
        public int Offset { get; }

        private GetCurrentUsersSavedTracksInput() { }

        public GetCurrentUsersSavedTracksInput(int limit, int offset) : this()
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
