using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/informationalurl?view=graph-rest-1.0
    /// </summary>
    public partial class InformationalUrl
    {
        public string? LogoUrl { get; set; }
        public string? MarketingUrl { get; set; }
        public string? PrivacyStatementUrl { get; set; }
        public string? SupportUrl { get; set; }
        public string? TermsOfServiceUrl { get; set; }
    }
}
