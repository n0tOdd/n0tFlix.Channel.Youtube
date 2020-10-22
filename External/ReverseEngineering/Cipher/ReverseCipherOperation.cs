using n0tFlix.YoutubeManager.Internal.Extensions;

namespace n0tFlix.YoutubeManager.ReverseEngineering.Cipher
{
    internal class ReverseCipherOperation : ICipherOperation
    {
        public string Decipher(string input) => input.Reverse();

        public override string ToString() => "Reverse";
    }
}