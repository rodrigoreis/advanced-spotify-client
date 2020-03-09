using System;
using System.Collections.Generic;
using AutoMapper;
using Spotify.Client.Domain.Gateways.Library;
using Spotify.Client.Domain.Models;
using SpotifyAPI.Web.Models;

namespace Spotify.Client.Infrastructure.Gateways.Library
{
    internal class LibraryEventHandler : ILibraryEventHandler
    {
        public event EventHandler<ITrack[]> OnListSavedTracks;
        public event EventHandler<Exception> OnListSavedTracksError;

        private readonly IMapper _mapper;

        public LibraryEventHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Invoke(Paging<SavedTrack> input)
        {
            var tracks = _mapper.Map<List<ITrack>>(input.Items).ToArray();
            OnListSavedTracks?.Invoke(this, tracks);
        }

        public void Error(Exception ex)
        {
            OnListSavedTracksError?.Invoke(this, ex);
        }
    }
}
