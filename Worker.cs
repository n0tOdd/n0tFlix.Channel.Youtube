using MediaBrowser.Controller.Channels;
using MediaBrowser.Model.Channels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using n0tFlix.YoutubeManager;
using MediaBrowser.Model.Dto;
using MediaBrowser.Controller.Entities;
using n0tFlix.YoutubeManager.Internal.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace n0tFlix.Channel.Youtube
{
    public class Worker
    {
        private readonly YoutubeClient youtubeClient;

        public Worker()
        {
            youtubeClient = new YoutubeClient();
        }

        public async Task<InternalChannelFeatures> GetChannelFeatures()
        {
            return new InternalChannelFeatures
            {
                MaxPageSize = Plugin.Instance.Configuration.MaxItems,
                SupportsContentDownloading = true,

                ContentTypes = new List<ChannelMediaContentType>
                {
                    ChannelMediaContentType.Clip,
                },
                MediaTypes = new List<ChannelMediaType>
                {
                    ChannelMediaType.Video,
                     ChannelMediaType.Audio,
                     ChannelMediaType.Photo
                },
            };
        }

        /// <summary>
        /// This function returns the main categories for our youtube channel
        /// basicly this is all the searchwords and custom channels we have pre inserted
        /// </summary>
        /// <returns></returns>
        public async Task<ChannelItemResult> GetChannelCategories()
        {
            return new ChannelItemResult
            {
                Items = new List<ChannelItemInfo>
                {
                    new ChannelItemInfo
                    {
                        Id = "channel=UC-9-kyTW8ZkZNDHQJ6FgpwQ",
                        FolderType = ChannelFolderType.Container,
                        Name = "Music",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCc4Rz_T9Sb1w5rqqo9pL1Og",
                        FolderType = ChannelFolderType.Container,
                        Name = "The Moon",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },

                    new ChannelItemInfo
                    {
                        Id = "Gaming",
                        FolderType = ChannelFolderType.Container,
                        Name = "Gaming",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Movies",
                        FolderType = ChannelFolderType.Container,
                        Name = "Movies",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Blockchain",
                        FolderType = ChannelFolderType.Container,
                        Name = "Blockchain",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Poker",
                        FolderType = ChannelFolderType.Container,
                        Name = "Poker",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Magic",
                        FolderType = ChannelFolderType.Container,
                        Name = "Magic",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Bitcoin",
                        FolderType = ChannelFolderType.Container,
                        Name = "Bitcoin",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Stand up",
                        FolderType = ChannelFolderType.Container,
                        Name = "Stand up",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "Sport",
                        FolderType = ChannelFolderType.Container,
                        Name = "Sport",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "list=PLU12uITxBEPF0ABXTAk32ZGt85byxL0sN",
                        FolderType = ChannelFolderType.Container,
                        Name = "Direkte",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UC1hHdUApytFUjhcag8VHikw",
                        FolderType = ChannelFolderType.Container,
                        Name = "Populært på YouTube–Norge",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCwWhs_6x42TyRM4Wstoq8HA",
                        FolderType = ChannelFolderType.Container,
                        Name = "The Daily Show with Trevor Noah",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCZ7QHqCYPE3Zi2Tt1sBobEw",
                        FolderType = ChannelFolderType.Container,
                        Name = "Vitenskapelige og teknologiske nyheter",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                                        new ChannelItemInfo
                    {
                        Id = "channel=UCcE169gw8kJCzyCJZXb7DQw",
                        FolderType = ChannelFolderType.Container,
                        Name = "Innenriksnyheter",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                     new ChannelItemInfo
                    {
                        Id = "channel=UCvAvFl2OGsuDSoOo93Kd0nA",
                        FolderType = ChannelFolderType.Container,
                        Name = "Utenriksnyheter",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                                     new ChannelItemInfo
                    {
                        Id = "channel=UCYfdidRxbB8Qhf0Nx7ioOYw",
                        FolderType = ChannelFolderType.Container,
                        Name = "Nyheter",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                  new ChannelItemInfo
                    {
                        Id = "channel=UCPDXXXJj9nax0fr0Wfc048g",
                        FolderType = ChannelFolderType.Container,
                        Name = "CollegeHumor",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCJ5v_MCY6GNUBTO8-D3XoAg",
                        FolderType = ChannelFolderType.Container,
                        Name = "WWE",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCfcyjCP9MOfYlV6gjR9odKA",
                        FolderType = ChannelFolderType.Container,
                        Name = "Transworld Skateboarding",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCXuqSBlHAE6Xw-yeJA0Tunw",
                        FolderType = ChannelFolderType.Container,
                        Name = "Linus Tech Tips",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCpT9kL2Eba91BB9CK6wJ4Pg",
                        FolderType = ChannelFolderType.Container,
                        Name = "TechSmartt",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCS5Oz6CHmeoF7vSad0qqXfw",
                        FolderType = ChannelFolderType.Container,
                        Name = "DanTDM",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UC9CuvdOVfMPvKCiwdGKL3cQ",
                        FolderType = ChannelFolderType.Container,
                        Name = "GameGrumps",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCSAUGyc_xA8uYzaIVG6MESQ",
                        FolderType = ChannelFolderType.Container,
                        Name = "nigahiga",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=UCS5Oz6CHmeoF7vSad0qqXfw",
                        FolderType = ChannelFolderType.Container,
                        Name = "DanTDM",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                    new ChannelItemInfo
                    {
                        Id = "channel=theHacksmith",
                        FolderType = ChannelFolderType.Container,
                        Name = "the Hacksmith",
                        Type = ChannelItemType.Folder, MediaType = ChannelMediaType.Video,
                    },
                },
                TotalRecordCount = 27
            };
        }

        /// <summary>
        /// this function is made to return all the videoes in the playlist
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private async Task<ChannelItemResult> GetPlayListItems(InternalChannelItemQuery query, IMemoryCache memoryCache)
        {
            string ListID = query.FolderId.Replace("list=", "");
            if (memoryCache.TryGetValue(ListID, out ChannelItemResult cachedValue))
            {
                // logger.LogInformation("Function={function} FolderId={folderId} Cache Hit", nameof(GetChannelItems), ChannelID);
                return cachedValue;
            }
            var videoes = await youtubeClient.Playlists.GetVideosAsync(ListID);
            ChannelItemResult result = new ChannelItemResult();
            foreach (var video in videoes)
            {
                result.Items.Add(new ChannelItemInfo()
                {
                    Id = video.Id,
                    Name = video.Title,
                    Overview = video.Description,
                    DateCreated = video.UploadDate.DateTime,
                    RunTimeTicks = video.Duration.Ticks,
                    HomePageUrl = video.Url,
                    ImageUrl = video.Thumbnails.MaxResUrl ?? video.Thumbnails.HighResUrl ?? video.Thumbnails.MediumResUrl ?? video.Thumbnails.StandardResUrl ?? video.Thumbnails.LowResUrl,
                    Type = ChannelItemType.Media,
                    ContentType = ChannelMediaContentType.Clip,
                    FolderType = ChannelFolderType.Container,
                    OriginalTitle = video.Title,
                    CommunityRating = (float?)video.Engagement.AverageRating,
                    MediaType = ChannelMediaType.Video,
                    People = new List<MediaBrowser.Controller.Entities.PersonInfo>() { new MediaBrowser.Controller.Entities.PersonInfo() {
                    Name = video.Author,
                    Role = "Author",
                    } },
                    OfficialRating = video.Engagement.ViewCount.ToString(),
                    PremiereDate = video.UploadDate.DateTime,
                    ProductionYear = video.UploadDate.DateTime.Year,
                });
                result.TotalRecordCount++;
            }
            memoryCache.Set(ListID, result, DateTimeOffset.Now.AddDays(1));

            return result;
        }

        /// <summary>
        /// This function is made to return all awailable videoes uploaded to the selected channel
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private async Task<ChannelItemResult> GetChannelItems(InternalChannelItemQuery query, IMemoryCache memoryCache)
        {
            string ChannelID = query.FolderId.Replace("channel=", "");
            if (memoryCache.TryGetValue(ChannelID, out ChannelItemResult cachedValue))
            {
                // logger.LogInformation("Function={function} FolderId={folderId} Cache Hit", nameof(GetChannelItems), ChannelID);
                return cachedValue;
            }
            IAsyncEnumerable<YoutubeManager.Videos.Video> videoes;
            if (ChannelID.Length >= 20)
                videoes = youtubeClient.Channels.GetUploadsAsync(ChannelID);
            else
                videoes = youtubeClient.Channels.GetUploadsAsync(youtubeClient.Channels.GetByUserAsync(ChannelID).GetAwaiter().GetResult().Id);
            ChannelItemResult result = new ChannelItemResult();
            var videoer = await videoes.ToListAsync();
            foreach (var video in videoer)
            {
                result.Items.Add(new ChannelItemInfo()
                {
                    Id = video.Id,
                    Name = video.Title,
                    Overview = video.Description,
                    DateCreated = video.UploadDate.DateTime,
                    RunTimeTicks = video.Duration.Ticks,
                    HomePageUrl = video.Url,
                    ImageUrl = video.Thumbnails.MaxResUrl ?? video.Thumbnails.HighResUrl ?? video.Thumbnails.MediumResUrl ?? video.Thumbnails.StandardResUrl ?? video.Thumbnails.LowResUrl,
                    Type = ChannelItemType.Media,
                    ContentType = ChannelMediaContentType.Clip,
                    FolderType = ChannelFolderType.Container,
                    OriginalTitle = video.Title,
                    CommunityRating = (float?)video.Engagement.AverageRating,
                    MediaType = ChannelMediaType.Video,
                    People = new List<MediaBrowser.Controller.Entities.PersonInfo>() { new MediaBrowser.Controller.Entities.PersonInfo() {
                    Name = video.Author,
                    Role = "Author",
                    } },
                    OfficialRating = video.Engagement.ViewCount.ToString(),
                    PremiereDate = video.UploadDate.DateTime,
                    ProductionYear = video.UploadDate.DateTime.Year,
                });
                result.TotalRecordCount++;
            }
            memoryCache.Set(ChannelID, result, DateTimeOffset.Now.AddDays(1));
            return result;
        }

        /// <summary>
        /// This function is made to return all the results from our search query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private async Task<ChannelItemResult> GetSearchResults(InternalChannelItemQuery query, IMemoryCache memoryCache)
        {
            if (memoryCache.TryGetValue(query.FolderId, out ChannelItemResult cachedValue))
            {
                // logger.LogInformation("Function={function} FolderId={folderId} Cache Hit", nameof(GetChannelItems), ChannelID);
                return cachedValue;
            }
            var videoes = await youtubeClient.Search.GetVideosAsync(query.FolderId, 0, 100);
            ChannelItemResult result = new ChannelItemResult();
            foreach (var video in videoes)
            {
                result.Items.Add(new ChannelItemInfo()
                {
                    Id = video.Id,
                    Name = video.Title,
                    Overview = video.Description,
                    DateCreated = video.UploadDate.DateTime,
                    RunTimeTicks = video.Duration.Ticks,
                    HomePageUrl = video.Url,
                    ImageUrl = video.Thumbnails.MaxResUrl ?? video.Thumbnails.HighResUrl ?? video.Thumbnails.MediumResUrl ?? video.Thumbnails.StandardResUrl ?? video.Thumbnails.LowResUrl,
                    Type = ChannelItemType.Media,
                    ContentType = ChannelMediaContentType.Clip,
                    FolderType = ChannelFolderType.Container,
                    OriginalTitle = video.Title,
                    CommunityRating = (float?)video.Engagement.AverageRating,
                    MediaType = ChannelMediaType.Video,
                    People = new List<MediaBrowser.Controller.Entities.PersonInfo>() { new MediaBrowser.Controller.Entities.PersonInfo() {
                    Name = video.Author,
                    Role = "Author",
                    } },
                    OfficialRating = video.Engagement.ViewCount.ToString(),
                    PremiereDate = video.UploadDate.DateTime,
                    ProductionYear = video.UploadDate.DateTime.Year,
                });
                result.TotalRecordCount++;
            }
            memoryCache.Set(query.FolderId, result, DateTimeOffset.Now.AddDays(1));
            return result;
        }

        public async Task<ChannelItemResult> GetChannelItems(InternalChannelItemQuery query, CancellationToken cancellationToken, IMemoryCache memoryCache)
        {
            if (string.IsNullOrEmpty(query.FolderId))
                return await GetChannelCategories();
            else if (query.FolderId.StartsWith("list="))
                return await GetPlayListItems(query, memoryCache);
            else if (query.FolderId.StartsWith("channel="))
                return await GetChannelItems(query, memoryCache);
            else
                return await GetSearchResults(query, memoryCache);

            return null;
        }

        /// <summary>
        /// This function was made to return the stream url we need to watch the video in n0tflix
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MediaSourceInfo>> GetChannelItemMediaInfo(string id, CancellationToken cancellationToken)
        {
            var videos = await youtubeClient.Videos.GetAsync(id);
            try
            {
                var manif = await youtubeClient.Videos.Streams.GetManifestAsync(videos.Id);
                List<MediaSourceInfo> mediaList = new List<MediaSourceInfo>();
                foreach (var video in manif.Streams)
                {
                    MediaSourceInfo mediaSourceInfo = new MediaSourceInfo()
                    {
                        Id = id,
                        Name = videos.Title,
                        IsRemote = true,
                        Type = MediaSourceType.Default,
                        Path = video.Url,
                        EncoderProtocol = MediaBrowser.Model.MediaInfo.MediaProtocol.Http,
                        Protocol = MediaBrowser.Model.MediaInfo.MediaProtocol.Http,
                    };
                    mediaList.Add(mediaSourceInfo);
                }

                return mediaList;
            }
            catch (Exception ex)
            {
                return new List<MediaSourceInfo>() { new MediaSourceInfo()
                {
                  Id = videos.Id,
                  Name = videos.Title,
                   IsRemote = true,
                   Path = await youtubeClient.Videos.Streams.GetHttpLiveStreamUrlAsync(videos.Id),
                    Protocol = MediaBrowser.Model.MediaInfo.MediaProtocol.Http
                } };
            }
        }
    }
}