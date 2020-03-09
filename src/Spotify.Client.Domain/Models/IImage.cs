namespace Spotify.Client.Domain.Models
{
    public interface IImage
    {
        int Height { get; }
        string Url { get; }
        string Width { get; }
    }
}
