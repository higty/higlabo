using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedorganizationPostInternalsponsorsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/internalSponsors/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors_ref,
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
    }
    public partial class ConnectedorganizationPostInternalsponsorsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync()
        {
            var p = new ConnectedorganizationPostInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationPostInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(ConnectedorganizationPostInternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationPostInternalsponsorsResponse> ConnectedorganizationPostInternalsponsorsAsync(ConnectedorganizationPostInternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationPostInternalsponsorsParameter, ConnectedorganizationPostInternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}
