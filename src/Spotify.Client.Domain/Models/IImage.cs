namespace Spotify.Client.Domain.Models
{
    public interface IImage
    {
        int Height { get; }
        string Url { get; }
        int Width { get; }
    }
}
