using System.Threading.Tasks;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Domain.Services
{
    public interface ILibraryService
    {
        Task<ITrack[]> ListSavedTracksAsync(int limit, int offset);
    }
}
