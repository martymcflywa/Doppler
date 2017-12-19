using System.IO;
using Newtonsoft.Json;

namespace Doppler.Core.Extension
{
    public static class JsonEx
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T Deserialize<T>(this Stream stream)
        {
            using(var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }

        public static string ToJson(this object @object)
        {
            return JsonConvert.SerializeObject(@object, Formatting.Indented);
        }
    }
}