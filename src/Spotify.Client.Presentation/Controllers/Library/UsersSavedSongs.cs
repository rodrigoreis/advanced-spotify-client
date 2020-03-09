using Microsoft.AspNetCore.Mvc;

namespace Spotify.Client.Presentation.Controllers.Library
{
    public class UsersSavedSongs : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
