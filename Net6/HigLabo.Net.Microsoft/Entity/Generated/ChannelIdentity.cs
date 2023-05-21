using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/channelidentity?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelIdentity
    {
        public string? ChannelId { get; set; }
        public string? TeamId { get; set; }
    }
}
