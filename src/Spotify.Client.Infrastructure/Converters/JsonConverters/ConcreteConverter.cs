using System;
using Newtonsoft.Json;

namespace Spotify.Client.Infrastructure.Converters.JsonConverters
{
    internal class ConcreteConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            /* TODO:
             futuramente implementar se o tipo implementa a interface decorada para já lançar que não pode 
             converter
             */
            true;

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer) =>
            serializer.Deserialize<T>(reader);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value);
    }
}
