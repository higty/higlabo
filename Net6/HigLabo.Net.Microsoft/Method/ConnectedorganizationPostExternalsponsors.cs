using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationPostExternalsponsorsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/externalSponsors/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ConnectedorganizationPostExternalsponsorsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync()
        {
            var p = new ConnectedorganizationPostExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationPostExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(ConnectedorganizationPostExternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(ConnectedorganizationPostExternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}
