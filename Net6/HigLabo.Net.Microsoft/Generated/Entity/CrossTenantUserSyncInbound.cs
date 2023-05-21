using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/crosstenantusersyncinbound?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantUserSyncInbound
    {
        public bool? IsSyncAllowed { get; set; }
    }
}
