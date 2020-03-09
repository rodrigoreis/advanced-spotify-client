namespace Spotify.Client.Domain.Models
{
    public interface IAlbum
    {
        string Id { get; }
        string Name { get; }
        IArtist[] Artists { get; }
        IImage[] Images { get; }
    }
}
