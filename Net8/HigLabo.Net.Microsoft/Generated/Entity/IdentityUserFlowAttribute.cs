using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identityuserflowattribute?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserFlowAttribute
    {
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeDataType
        {
            String,
            Boolean,
            Int64,
            StringCollection,
            DateTime,
        }
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeType
        {
            BuiltIn,
            Custom,
            Required,
        }

        public IdentityUserFlowAttributeIdentityUserFlowAttributeDataType DataType { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeType UserFlowAttributeType { get; set; }
    }
}
