using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Ui.Presenters.Library;
using Spotify.Client.Ui.ViewModels.Library;

namespace Spotify.Client.Ui.Controllers
{
    [Route("/[controller]")]
    public class LibraryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ListSavedTracksPresenter _presenter;

        public LibraryController(IMediator mediator, ListSavedTracksPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        [HttpGet]
        [Route("/list-saved-tracks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListSavedTracksViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListSavedTracks()
        {
            var input = new ListSavedTracksInput(20, 50);
            await _mediator.PublishAsync(input);
            return _presenter.Model;
        }
    }
}
