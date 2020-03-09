using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Client.Application.Boundaries.Library;
using Spotify.Client.Ui.ViewModels.Library;

namespace Spotify.Client.Ui.Presenters.Library
{
    public class ListSavedTracksPresenter : IListSavedTracksOutputPort
    {
        public IActionResult Model { get; private set; }

        public void Ok(ListSavedTracksOutput result)
        {
            Model = new ObjectResult("")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        public void InternalServerError(Exception exception)
        {
            /*
             * TODO: implementar o padrão "Problem Details"
             */
            Model = new ObjectResult(exception)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
