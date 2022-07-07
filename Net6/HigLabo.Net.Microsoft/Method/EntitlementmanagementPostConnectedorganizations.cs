using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementPostConnectedorganizationsParameter : IRestApiParameter
    {
        public enum EntitlementmanagementPostConnectedorganizationsParameterConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations: return $"/identityGovernance/entitlementManagement/connectedOrganizations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public IdentitySource[]? IdentitySources { get; set; }
        public EntitlementmanagementPostConnectedorganizationsParameterConnectedOrganizationState State { get; set; }
    }
    public partial class EntitlementmanagementPostConnectedorganizationsResponse : RestApiResponse
    {
        public enum ConnectedOrganizationConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySource[]? IdentitySources { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ConnectedOrganizationConnectedOrganizationState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostConnectedorganizationsResponse> EntitlementmanagementPostConnectedorganizationsAsync()
        {
            var p = new EntitlementmanagementPostConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementmanagementPostConnectedorganizationsParameter, EntitlementmanagementPostConnectedorganizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostConnectedorganizationsResponse> EntitlementmanagementPostConnectedorganizationsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementPostConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementmanagementPostConnectedorganizationsParameter, EntitlementmanagementPostConnectedorganizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostConnectedorganizationsResponse> EntitlementmanagementPostConnectedorganizationsAsync(EntitlementmanagementPostConnectedorganizationsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementPostConnectedorganizationsParameter, EntitlementmanagementPostConnectedorganizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostConnectedorganizationsResponse> EntitlementmanagementPostConnectedorganizationsAsync(EntitlementmanagementPostConnectedorganizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementPostConnectedorganizationsParameter, EntitlementmanagementPostConnectedorganizationsResponse>(parameter, cancellationToken);
        }
    }
}
