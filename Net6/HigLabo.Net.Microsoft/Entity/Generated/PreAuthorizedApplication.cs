using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/preauthorizedapplication?view=graph-rest-1.0
    /// </summary>
    public partial class PreAuthorizedApplication
    {
        public string? AppId { get; set; }
        public String[]? DelegatedPermissionIds { get; set; }
    }
}
