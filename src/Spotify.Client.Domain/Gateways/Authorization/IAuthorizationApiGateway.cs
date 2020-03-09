using System.Threading.Tasks;

namespace Spotify.Client.Domain.Gateways.Authorization
{
    public interface IAuthorizationApiGateway
    {
        Task AuthenticateAsync();
    }
}
