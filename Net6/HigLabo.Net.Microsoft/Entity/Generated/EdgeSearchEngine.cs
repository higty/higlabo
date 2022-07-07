using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-edgesearchengine?view=graph-rest-1.0
    /// </summary>
    public partial class EdgeSearchEngine
    {
        public enum EdgeSearchEngineEdgeSearchEngineType
        {
            Default,
            Bing,
        }

        public EdgeSearchEngineType EdgeSearchEngineType { get; set; }
    }
}
