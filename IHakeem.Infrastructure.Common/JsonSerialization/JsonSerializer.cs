using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace iHakeem.Infrastructure.Common.JsonSerialization
{
    /// <summary>
    /// JSON serializer, uses <see cref="JsonConvert"/> internally to be in sync with API serializer.
    /// </summary>
    public static class JsonSerializer
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = { new StringEnumConverter() },
        };

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, SerializerSettings);
        }

        public static object DeserializeObject(string value, Type objectType)
        {
            return JsonConvert.DeserializeObject(value, objectType, SerializerSettings);
        }

        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, SerializerSettings);
        }
    }
}
