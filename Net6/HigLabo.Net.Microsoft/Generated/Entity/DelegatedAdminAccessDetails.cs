using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminaccessdetails?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedAdminAccessDetails
    {
        public UnifiedRole[]? UnifiedRoles { get; set; }
    }
}
