using System.Threading.Tasks;

namespace Spotify.Client.Domain.Services
{
    public interface ILibraryService
    {
        Task ListSavedTracksAsync(int limit, int offset);
    }
}
