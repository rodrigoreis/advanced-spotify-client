using Spotify.Client.Domain.Models;

namespace Spotify.Client.Infrastructure.Entities
{
    internal class ExternalUrl : IExternalUrl
    {
        public string Spotify { get; set; }
    }
}
