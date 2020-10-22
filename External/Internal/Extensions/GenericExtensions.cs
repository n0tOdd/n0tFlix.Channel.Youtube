using System;

namespace n0tFlix.YoutubeManager.Internal.Extensions
{
    internal static class GenericExtensions
    {
        public static TOut Pipe<TIn, TOut>(this TIn input, Func<TIn, TOut> transform) => transform(input);
    }
}