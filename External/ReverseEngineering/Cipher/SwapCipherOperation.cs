using n0tFlix.YoutubeManager.Internal.Extensions;

namespace n0tFlix.YoutubeManager.ReverseEngineering.Cipher
{
    internal class SwapCipherOperation : ICipherOperation
    {
        private readonly int _index;

        public SwapCipherOperation(int index) => _index = index;

        public string Decipher(string input) => input.SwapChars(0, _index);

        public override string ToString() => $"Swap ({_index})";
    }
}