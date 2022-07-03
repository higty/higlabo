using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/applicationtemplate?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationTemplate
    {
        public String[] Categories { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string HomePageUrl { get; set; }
        public string Id { get; set; }
        public string LogoUrl { get; set; }
        public string Publisher { get; set; }
        public String[] SupportedProvisioningTypes { get; set; }
        public ApplicationTemplateString[] SupportedSingleSignOnModes { get; set; }
    }
}
