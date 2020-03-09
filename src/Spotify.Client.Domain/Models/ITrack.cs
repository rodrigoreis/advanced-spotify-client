namespace Spotify.Client.Domain.Models
{
    public interface ITrack
    {
        string Id { get; }
        IExternalUrl Url { get; }
        IAlbum Album { get; }
    }
}
