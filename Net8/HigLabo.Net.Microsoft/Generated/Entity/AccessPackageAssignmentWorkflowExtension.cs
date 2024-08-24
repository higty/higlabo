using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentworkflowextension?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentWorkflowExtension
    {
        public CustomExtensionAuthenticationConfiguration? AuthenticationConfiguration { get; set; }
        public CustomExtensionCallbackConfiguration? CallbackConfiguration { get; set; }
        public CustomExtensionClientConfiguration? ClientConfiguration { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public CustomExtensionEndpointConfiguration? EndpointConfiguration { get; set; }
        public string? Id { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
}
