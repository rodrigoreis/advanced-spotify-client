using FluentMediator;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Client.Ui.Controllers
{
    [Route("/[controller]")]
    public class AuthorizationController : Controller
    {
        public IActionResult Authenticate()
        {
            return View();
        }
    }
}
