using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/website?view=graph-rest-1.0
    /// </summary>
    public partial class Website
    {
        public WebsiteWebsiteType Type { get; set; }
        public String? Address { get; set; }
        public String? DisplayName { get; set; }
    }
}
