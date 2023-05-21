using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccesstemplate?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessTemplate
    {
        public enum ConditionalAccessTemplateTemplateScenarios
        {
            New,
            SecureFoundation,
            ZeroTrust,
            RemoteWork,
            ProtectAdmins,
            EmergingThreats,
            UnknownFutureValue,
            Has,
        }

        public string? Description { get; set; }
        public ConditionalAccessPolicyDetail? Details { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ConditionalAccessTemplateTemplateScenarios Scenarios { get; set; }
    }
}
