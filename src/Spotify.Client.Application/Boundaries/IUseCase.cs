using System.Threading.Tasks;

namespace Spotify.Client.Application.Boundaries
{
    public interface IUseCase<in TInput>
    {
        Task ExecuteAsync(TInput input);
    }
}
