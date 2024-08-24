using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-indicator?view=graph-rest-1.0
    /// </summary>
    public partial class Indicator
    {
        public enum IndicatorSecurityIndicatorSource
        {
            MicrosoftDefenderThreatIntelligence,
            OpenSourceIntelligence,
            Public,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public IndicatorSecurityIndicatorSource Source { get; set; }
        public Artifact? Artifact { get; set; }
    }
}
