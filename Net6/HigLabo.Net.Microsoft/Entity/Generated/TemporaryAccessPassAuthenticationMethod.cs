using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/temporaryaccesspassauthenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class TemporaryAccessPassAuthenticationMethod
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsUsable { get; set; }
        public bool? IsUsableOnce { get; set; }
        public Int32? LifetimeInMinutes { get; set; }
        public string? MethodUsabilityReason { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? TemporaryAccessPass { get; set; }
    }
}
