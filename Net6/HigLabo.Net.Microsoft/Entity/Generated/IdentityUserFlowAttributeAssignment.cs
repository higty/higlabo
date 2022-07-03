using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/identityuserflowattributeassignment?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserFlowAttributeAssignment
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsOptional { get; set; }
        public bool RequiresVerification { get; set; }
        public UserAttributeValuesItem[] UserAttributeValues { get; set; }
        public IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType UserInputType { get; set; }
    }
}
