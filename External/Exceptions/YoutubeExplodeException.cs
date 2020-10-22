using System;

namespace n0tFlix.YoutubeManager.Exceptions
{
    /// <summary>
    /// Parent class for domain exceptions thrown by <see cref="n0tFlix.YoutubeManager"/>.
    /// </summary>
    public abstract class YoutubeManagerException : Exception
    {
        /// <summary>
        /// Initializes an instance of <see cref="n0tFlix.YoutubeManagerException"/>.
        /// </summary>
        /// <param name="message"></param>
        protected YoutubeManagerException(string message)
            : base(message)
        {
        }
    }
}