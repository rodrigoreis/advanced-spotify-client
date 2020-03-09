using Newtonsoft.Json;
using Spotify.Client.Domain.Models;
using Spotify.Client.Infrastructure.Converters.JsonConverters;

namespace Spotify.Client.Infrastructure.Entities
{
    internal class Album : IAlbum
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Artist[]>))]
        public IArtist[] Artists { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Image[]>))]
        public IImage[] Images { get; set; }
    }
}
