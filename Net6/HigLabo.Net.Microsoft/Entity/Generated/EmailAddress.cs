using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/emailaddress?view=graph-rest-1.0
    /// </summary>
    public partial class EmailAddress
    {
        public string? Address { get; set; }
        public string? Name { get; set; }
    }
}
