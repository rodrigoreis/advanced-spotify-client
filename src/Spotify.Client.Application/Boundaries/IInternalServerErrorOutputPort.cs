using System;

namespace Spotify.Client.Application.Boundaries
{
    public interface IInternalServerErrorOutputPort<in TException> where  TException : Exception
    {
        void InternalServerError(TException exception);
    }
}
