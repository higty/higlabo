using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementPostConnectedOrganizationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations: return $"/identityGovernance/entitlementManagement/connectedOrganizations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EntitlementManagementPostConnectedOrganizationsParameterConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
        }
        public enum ConnectedOrganizationConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public IdentitySource[]? IdentitySources { get; set; }
        public EntitlementManagementPostConnectedOrganizationsParameterConnectedOrganizationState State { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public DirectoryObject[]? ExternalSponsors { get; set; }
        public DirectoryObject[]? InternalSponsors { get; set; }
    }
    public partial class EntitlementManagementPostConnectedOrganizationsResponse : RestApiResponse
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
        public DirectoryObject[]? ExternalSponsors { get; set; }
        public DirectoryObject[]? InternalSponsors { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementPostConnectedOrganizationsResponse> EntitlementManagementPostConnectedOrganizationsAsync()
        {
            var p = new EntitlementManagementPostConnectedOrganizationsParameter();
            return await this.SendAsync<EntitlementManagementPostConnectedOrganizationsParameter, EntitlementManagementPostConnectedOrganizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementPostConnectedOrganizationsResponse> EntitlementManagementPostConnectedOrganizationsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementPostConnectedOrganizationsParameter();
            return await this.SendAsync<EntitlementManagementPostConnectedOrganizationsParameter, EntitlementManagementPostConnectedOrganizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementPostConnectedOrganizationsResponse> EntitlementManagementPostConnectedOrganizationsAsync(EntitlementManagementPostConnectedOrganizationsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementPostConnectedOrganizationsParameter, EntitlementManagementPostConnectedOrganizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementPostConnectedOrganizationsResponse> EntitlementManagementPostConnectedOrganizationsAsync(EntitlementManagementPostConnectedOrganizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementPostConnectedOrganizationsParameter, EntitlementManagementPostConnectedOrganizationsResponse>(parameter, cancellationToken);
        }
    }
}
