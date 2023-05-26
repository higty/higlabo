using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/usertrainingcontenteventinfo?view=graph-rest-1.0
    /// </summary>
    public partial class UserTrainingContentEventInfo
    {
        public string? Browser { get; set; }
        public DateTimeOffset? ContentDateTime { get; set; }
        public string? IpAddress { get; set; }
        public string? OsPlatformDeviceDetails { get; set; }
        public Double? PotentialScoreImpact { get; set; }
    }
}
