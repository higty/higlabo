using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-onpremisesconditionalaccesssettings?view=graph-rest-1.0
    /// </summary>
    public partial class OnPremisesConditionalAccessSettings
    {
        public string? Id { get; set; }
        public bool? Enabled { get; set; }
        public Guid[]? IncludedGroups { get; set; }
        public Guid[]? ExcludedGroups { get; set; }
        public bool? OverrideDefaultRule { get; set; }
    }
}
