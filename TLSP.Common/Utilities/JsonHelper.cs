using System.Text.Json;
using System.IO;
namespace TLSP.Common.Utilities
{
    public static class JsonHelper
    {
        public static T ReadFormFile<T>(string path) => JsonSerializer.Deserialize<T>(File.ReadAllText(path));
        public static void WriteToFile<T>(string path, T entity) => File.WriteAllText(path, JsonSerializer.Serialize(entity));
    }
}
