using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Serialization;
using n0tFlix.Channel.Youtube.Configuration;
using System;

namespace n0tFlix.Channel.Youtube
{
    public class Plugin : BasePlugin<PluginConfiguration>
    {
        /// <summary>
        /// The name of our plugin
        /// </summary>
        public override string Name => "Youtube";

        /// <summary>
        /// Description of the plugin
        /// </summary>
        public override string Description => "Watch youtube all day long";

        public override Guid Id => Guid.Parse("f2b4840e-43bb-4e3d-abc4-0f63dcae58ea");

        /// <summary>
        /// Gets the plugin instance.
        /// </summary>
        public static Plugin Instance { get; private set; }

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
    : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }
    }
}