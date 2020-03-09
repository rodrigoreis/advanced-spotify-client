using Spotify.Client.Domain.Models;

namespace Spotify.Client.Infrastructure.Entities
{
    internal class Artist : IArtist
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
