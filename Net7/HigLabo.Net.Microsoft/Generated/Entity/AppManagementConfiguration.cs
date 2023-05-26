using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/appmanagementconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementConfiguration
    {
        public PasswordCredentialConfiguration[]? PasswordCredentials { get; set; }
        public KeyCredentialConfiguration[]? KeyCredentials { get; set; }
    }
}
