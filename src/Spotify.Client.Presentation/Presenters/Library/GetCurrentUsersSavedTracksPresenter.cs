using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Client.Application.Boundaries.Library;

namespace Spotify.Client.Presentation.Presenters.Library
{
    public class GetCurrentUsersSavedTracksPresenter : IGetCurrentUsersSavedTracksOutputPort
    {
        public IActionResult Model { get; private set; }

        public void Ok(GetCurrentUsersSavedTracksOutput result)
        {
            /*
             * TODO: implementar a chamada ao viewmodel desta visão
             */
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
