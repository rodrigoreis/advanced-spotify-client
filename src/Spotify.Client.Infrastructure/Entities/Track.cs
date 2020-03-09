using Spotify.Client.Domain.Models;

namespace Spotify.Client.Infrastructure.Entities
{
    internal class Track : ITrack
    {
        public string Id { get; set; }

        public IExternalUrl Url { get; set; }

        public IAlbum Album { get; set; }
    }
}
