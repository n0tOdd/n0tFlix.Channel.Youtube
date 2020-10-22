namespace n0tFlix.YoutubeManager.Videos.Streams
{
    /// <summary>
    /// YouTube media stream that contains audio.
    /// </summary>
    public interface IAudioStreamInfo : IStreamInfo
    {
        /// <summary>
        /// Audio codec.
        /// </summary>
        string AudioCodec { get; }
    }
}