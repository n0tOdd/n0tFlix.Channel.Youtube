using MediaBrowser.Controller.Channels;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Drawing;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace n0tFlix.Channel.Youtube
{
    public class YoutubeChannel : IChannel, IRequiresMediaInfoCallback, ISupportsLatestMedia
    {
        private readonly IMemoryCache memoryCache;
        private readonly TimeSpan defaultCacheTime = TimeSpan.FromDays(1);

        // private readonly Worker worker;
        private readonly ILogger<YoutubeChannel> logger;

        private readonly Worker worker;
        public string Name => "Youtube";

        public string Description => "A channel to let you watch all youre favorite youtube videos";

        public string DataVersion => "1.0.0.1";

        public string HomePageUrl => "https://n0tprojects.com";
        public ChannelParentalRating ParentalRating => ChannelParentalRating.GeneralAudience;

        public bool IsEnabledFor(string userId)
        {
            return true;
        }

        public YoutubeChannel(ILogger<YoutubeChannel> logger, IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.memoryCache = memoryCache;
            this.worker = new Worker();
        }

        #region Schedualed tasks to run some needed code

        public async Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
        {
            //            await worker.GetAllChannelItems(true, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
        {
            yield return new TaskTriggerInfo
            {
                Type = TaskTriggerInfo.TriggerStartup
            };

            yield return new TaskTriggerInfo
            {
                Type = TaskTriggerInfo.TriggerDaily,
                TimeOfDayTicks = TimeSpan.FromHours(1).Ticks
            };
            yield return new TaskTriggerInfo
            {
                Type = TaskTriggerInfo.TriggerInterval,
                IntervalTicks = TimeSpan.FromHours(1).Ticks
            };
        }

        #endregion Schedualed tasks to run some needed code

        #region Channel images

        public async Task<DynamicImageResponse> GetChannelImage(ImageType type, CancellationToken cancellationToken)
        {
            logger.LogDebug(nameof(GetChannelImage));
            if (type == ImageType.Thumb || type == ImageType.Primary)
            {
                var name = "n0tFlix.Channel.Youtube.Images.logo.png";
                var response = new DynamicImageResponse
                {
                    Format = ImageFormat.Png,
                    HasImage = true,
                    Stream = GetType().Assembly.GetManifestResourceStream(name)
                };

                return response;
            }

            return await Task.FromResult<DynamicImageResponse>(null);
        }

        public IEnumerable<ImageType> GetSupportedChannelImages()
        {
            return new List<ImageType>
            {
                ImageType.Thumb,
                ImageType.Primary
            };
        }

        #endregion Channel images

        public async Task<ChannelItemResult> GetChannelItems(InternalChannelItemQuery query, CancellationToken cancellationToken)
            => await worker.GetChannelItems(query, cancellationToken, memoryCache);

        public InternalChannelFeatures GetChannelFeatures()
            => worker.GetChannelFeatures().GetAwaiter().GetResult();

        public async Task<IEnumerable<MediaSourceInfo>> GetChannelItemMediaInfo(string id, CancellationToken cancellationToken)
         => await worker.GetChannelItemMediaInfo(id, cancellationToken);

        public async Task<IEnumerable<ChannelItemInfo>> GetLatestMedia(ChannelLatestMediaSearch request, CancellationToken cancellationToken)
         => worker.GetChannelItems(new InternalChannelItemQuery() { FolderId = worker.GetChannelCategories().Result.Items.ElementAt(new Random().Next(0, 26)).Id }, cancellationToken, memoryCache).Result.Items;
    }
}