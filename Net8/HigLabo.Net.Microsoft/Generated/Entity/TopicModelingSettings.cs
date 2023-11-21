using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-topicmodelingsettings?view=graph-rest-1.0
    /// </summary>
    public partial class TopicModelingSettings
    {
        public bool? DynamicallyAdjustTopicCount { get; set; }
        public bool? IgnoreNumbers { get; set; }
        public bool? IsEnabled { get; set; }
        public Int32? TopicCount { get; set; }
    }
}
