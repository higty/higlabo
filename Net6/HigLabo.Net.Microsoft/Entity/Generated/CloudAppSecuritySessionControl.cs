using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudappsecuritysessioncontrol?view=graph-rest-1.0
    /// </summary>
    public partial class CloudAppSecuritySessionControl
    {
        public enum CloudAppSecuritySessionControlCloudAppSecuritySessionControlType
        {
            McasConfigured,
            MonitorOnly,
            BlockDownloads,
            UnknownFutureValue,
        }

        public CloudAppSecuritySessionControlCloudAppSecuritySessionControlType CloudAppSecurityType { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
