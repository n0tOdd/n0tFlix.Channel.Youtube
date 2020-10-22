using MediaBrowser.Model.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace n0tFlix.Channel.Youtube.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public string YoutubeApiKey = "AIzaSyA8WQZHwxcYA0-4cLPsbJwvEOX2CQmBUso";
        public bool IgnoreCache = false;
        public int MaxItems = 3;
        public string FirstSearchWord = "random funny stuff";
    }
}