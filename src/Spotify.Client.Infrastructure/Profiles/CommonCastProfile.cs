using System;
using System.Text;
using AutoMapper;

namespace Spotify.Client.Infrastructure.Profiles
{
    public class CommonCastProfile : Profile
    {
        public CommonCastProfile()
        {
            CreateMap<decimal?, long?>()
                .ConvertUsing(x => (long?) x);

            CreateMap<long?, decimal?>()
                .ConvertUsing(x => (decimal?) x);

            CreateMap<decimal, long>()
                .ConvertUsing(x => (long) x);

            CreateMap<long, decimal>()
                .ConvertUsing(x => (decimal) x);

            CreateMap<decimal?, int?>()
                .ConvertUsing(x => (int?) x);

            CreateMap<int?, decimal?>()
                .ConvertUsing(x => (decimal?) x);

            CreateMap<decimal, int>()
                .ConvertUsing(x => (int) x);

            CreateMap<int, decimal>()
                .ConvertUsing(x => (decimal) x);

            CreateMap<string, Guid>()
                .ConvertUsing(x => new Guid(x));

            CreateMap<Guid, string>()
                .ConvertUsing(x => x.ToString());

            CreateMap<string, byte[]>()
                .ConvertUsing(x => Encoding.UTF8.GetBytes(x));

            CreateMap<byte[], string>()
                .ConvertUsing(x => Encoding.UTF8.GetString(x));

            CreateMap<byte, byte[]>()
                .ConvertUsing(x => new[] { x });
        }
    }
}
