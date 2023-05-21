using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverycasesettings?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryCaseSettings
    {
        public string? Id { get; set; }
        public OcrSettings? Ocr { get; set; }
        public RedundancyDetectionSettings? RedundancyDetection { get; set; }
        public TopicModelingSettings? TopicModeling { get; set; }
    }
}
