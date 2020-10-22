using System.Text.Json;

namespace n0tFlix.YoutubeManager.Internal.Extensions
{
    internal static class JsonElementExtensions
    {
        public static JsonElement? GetPropertyOrNull(this JsonElement element, string propertyName) =>
            element.TryGetProperty(propertyName, out var result) ? result : (JsonElement?) null;
    }
}