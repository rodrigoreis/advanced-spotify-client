using System.Collections.Generic;

namespace Spotify.Client.Domain.Validations
{
    public interface IValidator<in T>
    {
        IEnumerable<IValidationError> Validate(T model);
    }
}
