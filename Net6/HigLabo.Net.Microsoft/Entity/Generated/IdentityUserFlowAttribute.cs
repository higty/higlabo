using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/identityuserflowattribute?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserFlowAttribute
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeType UserFlowAttributeType { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeDataType DataType { get; set; }
    }
}
