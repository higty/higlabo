using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectedOrganizationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ConnectedorganizationUpdateParameterConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public IdentitySource[]? IdentitySources { get; set; }
        public ConnectedorganizationUpdateParameterConnectedOrganizationState State { get; set; }
    }
    public partial class ConnectedorganizationUpdateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationUpdateResponse> ConnectedorganizationUpdateAsync()
        {
            var p = new ConnectedorganizationUpdateParameter();
            return await this.SendAsync<ConnectedorganizationUpdateParameter, ConnectedorganizationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationUpdateResponse> ConnectedorganizationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationUpdateParameter();
            return await this.SendAsync<ConnectedorganizationUpdateParameter, ConnectedorganizationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationUpdateResponse> ConnectedorganizationUpdateAsync(ConnectedorganizationUpdateParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationUpdateParameter, ConnectedorganizationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationUpdateResponse> ConnectedorganizationUpdateAsync(ConnectedorganizationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationUpdateParameter, ConnectedorganizationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
