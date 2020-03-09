using Newtonsoft.Json;

namespace Spotify.Client.Infrastructure.Extensions
{
    internal static class SerializationExtensions
    {
        private static JsonSerializerSettings CreateJsonSerializerSettings() =>
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

        public static string Serialize<T>(this T instance) =>
            JsonConvert.SerializeObject(
                instance,
                Formatting.Indented,
                CreateJsonSerializerSettings()
            );

        public static T Deserialize<T>(this string serializedObject) =>
            JsonConvert.DeserializeObject<T>(
                serializedObject,
                CreateJsonSerializerSettings()
            );
    }
}
