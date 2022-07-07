using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationPostInternalsponsorsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/internalSponsors/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ConnectedorganizationPostInternalsponsorsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync()
        {
            var p = new ConnectedorganizationPostInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationPostInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(ConnectedorganizationPostInternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(ConnectedorganizationPostInternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}
