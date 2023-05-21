using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-redundancydetectionsettings?view=graph-rest-1.0
    /// </summary>
    public partial class RedundancyDetectionSettings
    {
        public bool? IsEnabled { get; set; }
        public Int32? MaxWords { get; set; }
        public Int32? MinWords { get; set; }
        public Int32? SimilarityThreshold { get; set; }
    }
}
