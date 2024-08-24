using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventpresenterdetails?view=graph-rest-1.0
    /// </summary>
    public partial class VirtualEventPresenterDetails
    {
        public ItemBody? Bio { get; set; }
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string? LinkedInProfileWebUrl { get; set; }
        public string? PersonalSiteWebUrl { get; set; }
        public Stream? Photo { get; set; }
        public string? TwitterProfileWebUrl { get; set; }
    }
}
