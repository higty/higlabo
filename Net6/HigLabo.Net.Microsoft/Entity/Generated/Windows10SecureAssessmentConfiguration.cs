using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10secureassessmentconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class Windows10SecureAssessmentConfiguration
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? LaunchUri { get; set; }
        public string? ConfigurationAccount { get; set; }
        public bool? AllowPrinting { get; set; }
        public bool? AllowScreenCapture { get; set; }
        public bool? AllowTextSuggestion { get; set; }
    }
}
