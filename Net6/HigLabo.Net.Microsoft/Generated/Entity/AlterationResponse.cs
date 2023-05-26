using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/alterationresponse?view=graph-rest-1.0
    /// </summary>
    public partial class AlterationResponse
    {
        public enum AlterationResponseSearchAlterationType
        {
            Suggestion,
            Modification,
        }

        public string? OriginalQueryString { get; set; }
        public SearchAlteration? QueryAlteration { get; set; }
        public AlterationResponseSearchAlterationType QueryAlterationType { get; set; }
    }
}
