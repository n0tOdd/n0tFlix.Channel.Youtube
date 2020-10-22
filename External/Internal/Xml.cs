using System.Xml.Linq;
using n0tFlix.YoutubeManager.Internal.Extensions;

namespace n0tFlix.YoutubeManager.Internal
{
    internal static class Xml
    {
        public static XElement Parse(string source) => XElement.Parse(source, LoadOptions.PreserveWhitespace).StripNamespaces();
    }
}