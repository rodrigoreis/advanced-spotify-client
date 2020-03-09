using System.Linq;
using AutoMapper;
using Spotify.Client.Domain.Models;
using Spotify.Client.Infrastructure.Entities;
using SpotifyAPI.Web.Models;
using Image = Spotify.Client.Infrastructure.Entities.Image;

namespace Spotify.Client.Infrastructure.Converters.TypeConverters
{
    public class SavedTrackToTrackTypeConverter : ITypeConverter<SavedTrack, ITrack>
    {
        public ITrack Convert(SavedTrack source, ITrack destination, ResolutionContext context)
        {

            var albunsArtists = source.Track.Album.Artists.Select(i => new Artist
            {
                Id = i.Id,
                Name = i.Name
            });
            
            var albunsImages = source.Track.Album.Images.Select(i => new Image
            {
                Url = i.Url,
                Height = i.Height,
                Width = i.Width
            });
            
            var album = new Album
            {
                Id = source.Track.Album.Id,
                Name = source.Track.Album.Name,
                Images = albunsImages.ToArray<IImage>(),
                Artists = albunsArtists.ToArray<IArtist>(),
            };

            var externalUrl = new ExternalUrl
            {
                Spotify = source.Track.ExternUrls[nameof(Spotify)]
            };
            
            return new Track
            {
                Id = source.Track.Id,
                Album = album,
                Url = externalUrl
            };
        }
    }
}
