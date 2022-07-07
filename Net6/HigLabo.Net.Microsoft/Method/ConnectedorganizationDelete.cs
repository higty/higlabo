using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectedOrganizationId { get; set; }
    }
    public partial class ConnectedorganizationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteResponse> ConnectedorganizationDeleteAsync()
        {
            var p = new ConnectedorganizationDeleteParameter();
            return await this.SendAsync<ConnectedorganizationDeleteParameter, ConnectedorganizationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteResponse> ConnectedorganizationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationDeleteParameter();
            return await this.SendAsync<ConnectedorganizationDeleteParameter, ConnectedorganizationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteResponse> ConnectedorganizationDeleteAsync(ConnectedorganizationDeleteParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationDeleteParameter, ConnectedorganizationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteResponse> ConnectedorganizationDeleteAsync(ConnectedorganizationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationDeleteParameter, ConnectedorganizationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
