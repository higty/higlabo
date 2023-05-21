using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-loggedonuser?view=graph-rest-1.0
    /// </summary>
    public partial class LoggedOnUser
    {
        public string? AccountName { get; set; }
        public string? DomainName { get; set; }
    }
}
