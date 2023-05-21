using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/emailauthenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class EmailAuthenticationMethod
    {
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
    }
}
