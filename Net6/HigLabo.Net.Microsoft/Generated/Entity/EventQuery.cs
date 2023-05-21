using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-eventquery?view=graph-rest-1.0
    /// </summary>
    public partial class EventQuery
    {
        public enum EventQuerySecurityQueryType
        {
            Files,
            Messages,
            UnknownFutureValue,
        }

        public EventQuerySecurityQueryType QueryType { get; set; }
        public string? Query { get; set; }
    }
}
