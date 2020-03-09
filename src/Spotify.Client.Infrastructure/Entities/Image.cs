using Spotify.Client.Domain.Models;

namespace Spotify.Client.Infrastructure.Entities
{
    internal class Image : IImage
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }
}
