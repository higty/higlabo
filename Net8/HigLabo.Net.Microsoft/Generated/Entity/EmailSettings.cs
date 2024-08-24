using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/emailsettings?view=graph-rest-1.0
    /// </summary>
    public partial class EmailSettings
    {
        public string? SenderDomain { get; set; }
        public bool? UseCompanyBranding { get; set; }
    }
}
