using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/searchhit?view=graph-rest-1.0
    /// </summary>
    public partial class SearchHit
    {
        public string ContentSource { get; set; }
        public string HitId { get; set; }
        public Int32? Rank { get; set; }
        public string ResultTemplateId { get; set; }
        public Entity? Resource { get; set; }
        public string Summary { get; set; }
    }
}
