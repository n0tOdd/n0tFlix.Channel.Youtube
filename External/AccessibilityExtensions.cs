using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using n0tFlix.YoutubeManager.Internal.Extensions;
using n0tFlix.YoutubeManager.Videos;

namespace n0tFlix.YoutubeManager
{
    /// <summary>
    /// Extensions to make working with <see cref="n0tFlix.YoutubeManager"/> a bit more comfortable.
    /// </summary>
    public static class AccessibilityExtensions
    {
        /// <summary>
        /// Buffers the asynchronous list of videos in memory.
        /// </summary>
        public static async ValueTask<IReadOnlyList<Video>> BufferAsync(this IAsyncEnumerable<Video> asyncVideoEnumerable) =>
            await asyncVideoEnumerable.ToListAsync();

        /// <summary>
        /// Buffers the asynchronous list of videos in memory, up to the specified number of videos.
        /// </summary>
        public static async ValueTask<IReadOnlyList<Video>> BufferAsync(this IAsyncEnumerable<Video> asyncVideoEnumerable, int count) =>
            await asyncVideoEnumerable.TakeAsync(count).BufferAsync();

        /// <summary>
        /// Gets the awaiter that encapsulates an operation that buffers a list of videos in-memory,
        /// </summary>
        public static ValueTaskAwaiter<IReadOnlyList<Video>> GetAwaiter(this IAsyncEnumerable<Video> asyncVideoEnumerable) =>
            asyncVideoEnumerable.BufferAsync().GetAwaiter();
    }
}