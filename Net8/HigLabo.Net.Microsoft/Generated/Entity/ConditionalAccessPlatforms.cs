using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessplatforms?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessPlatforms
    {
        public enum ConditionalAccessPlatformsConditionalAccessDevicePlatform
        {
            Android,
            IOS,
            Windows,
            WindowsPhone,
            MacOS,
            Linux,
            All,
            UnknownFutureValue,
        }

        public ConditionalAccessPlatformsConditionalAccessDevicePlatform ExcludePlatforms { get; set; }
        public ConditionalAccessPlatformsConditionalAccessDevicePlatform IncludePlatforms { get; set; }
    }
}
