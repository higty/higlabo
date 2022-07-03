using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sitecollection?view=graph-rest-1.0
    /// </summary>
    public partial class SiteCollection
    {
        public String? Hostname { get; set; }
        public String? DataLocationCode { get; set; }
        public Root? Root { get; set; }
    }
}
