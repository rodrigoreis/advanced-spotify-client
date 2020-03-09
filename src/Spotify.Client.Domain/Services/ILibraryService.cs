using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Client.Domain.Models;

namespace Spotify.Client.Domain.Services
{
    public interface ILibraryService
    {
        Task<IEnumerable<ITrack>> GetCurrentUsersSavedTracksAsync(int limit, int offset);
    }
}
