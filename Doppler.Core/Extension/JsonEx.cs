using System.IO;
using Newtonsoft.Json;

namespace Doppler.Core.Extension
{
    public static class JsonEx
    {
        public static TProxy Deserialize<TProxy>(this string json) where TProxy : class
        {
            return JsonConvert.DeserializeObject<TProxy>(json);
        }

        public static TProxy Deserialize<TProxy>(this Stream stream) where TProxy : class
        {
            using(var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<TProxy>(jsonReader);
            }
        }
    }
}