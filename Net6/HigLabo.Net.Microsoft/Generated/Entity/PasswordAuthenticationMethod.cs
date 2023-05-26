using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/passwordauthenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class PasswordAuthenticationMethod
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Password { get; set; }
    }
}
