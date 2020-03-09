using AutoMapper;
using Spotify.Client.Domain.Models;
using Spotify.Client.Infrastructure.Converters.TypeConverters;
using SpotifyAPI.Web.Models;

namespace Spotify.Client.Infrastructure.Profiles.Library
{
    public class SavedTrackToTrackProfile : Profile
    {
        public SavedTrackToTrackProfile()
        {
            CreateMap<SavedTrack, ITrack>().ConvertUsing<SavedTrackToTrackTypeConverter>();
        }
    }
}
