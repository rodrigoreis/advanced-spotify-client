using System.Threading.Tasks;

namespace Spotify.Client.Domain.Services
{
    public interface IAuthorizationService
    {
        Task AuthenticateAsync();
    }
}
