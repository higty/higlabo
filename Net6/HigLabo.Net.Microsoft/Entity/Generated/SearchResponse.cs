using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/searchresponse?view=graph-rest-1.0
    /// </summary>
    public partial class SearchResponse
    {
        public SearchHitsContainer[]? HitsContainers { get; set; }
        public ResultTemplate[]? ResultTemplates { get; set; }
        public String[]? SearchTerms { get; set; }
        public AlterationResponse? QueryAlterationResponse { get; set; }
    }
}
