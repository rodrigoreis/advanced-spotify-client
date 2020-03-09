namespace Spotify.Client.Infrastructure.Gateways
{
    public class SpotifyCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string ServerUri { get; set; }
    }
}
