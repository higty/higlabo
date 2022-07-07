using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationDeleteInternalsponsorsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId_InternalSponsors_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId_InternalSponsors_Id_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}/internalSponsors/{Id}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectedOrganizationId { get; set; }
        public string Id { get; set; }
    }
    public partial class ConnectedorganizationDeleteInternalsponsorsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteInternalsponsorsResponse> ConnectedorganizationDeleteInternalsponsorsAsync()
        {
            var p = new ConnectedorganizationDeleteInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationDeleteInternalsponsorsParameter, ConnectedorganizationDeleteInternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteInternalsponsorsResponse> ConnectedorganizationDeleteInternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationDeleteInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationDeleteInternalsponsorsParameter, ConnectedorganizationDeleteInternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteInternalsponsorsResponse> ConnectedorganizationDeleteInternalsponsorsAsync(ConnectedorganizationDeleteInternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationDeleteInternalsponsorsParameter, ConnectedorganizationDeleteInternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-delete-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationDeleteInternalsponsorsResponse> ConnectedorganizationDeleteInternalsponsorsAsync(ConnectedorganizationDeleteInternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationDeleteInternalsponsorsParameter, ConnectedorganizationDeleteInternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}
