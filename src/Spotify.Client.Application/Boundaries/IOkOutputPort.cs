namespace Spotify.Client.Application.Boundaries
{
    public interface IOkOutputPort<in TResult>
    {
        void Ok(TResult result);
    }
}
