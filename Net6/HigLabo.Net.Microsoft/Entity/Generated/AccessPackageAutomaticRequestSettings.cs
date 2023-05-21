using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageautomaticrequestsettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAutomaticRequestSettings
    {
        public bool? RequestAccessForAllowedTargets { get; set; }
    }
}
