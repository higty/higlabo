using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sharepointidentityset?view=graph-rest-1.0
    /// </summary>
    public partial class SharePointIdentitySet
    {
        public Identity? Application { get; set; }
        public Identity? Device { get; set; }
        public Identity? Group { get; set; }
        public Identity? User { get; set; }
        public SharePointIdentity? SiteUser { get; set; }
        public SharePointIdentity? SiteGroup { get; set; }
    }
}
