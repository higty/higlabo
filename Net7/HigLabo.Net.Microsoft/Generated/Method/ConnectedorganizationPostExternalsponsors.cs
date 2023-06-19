using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedorganizationPostExternalsponsorsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/externalSponsors/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors_ref,
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
    public partial class ConnectedorganizationPostExternalsponsorsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync()
        {
            var p = new ConnectedorganizationPostExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationPostExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(ConnectedorganizationPostExternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-post-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationPostExternalsponsorsResponse> ConnectedorganizationPostExternalsponsorsAsync(ConnectedorganizationPostExternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationPostExternalsponsorsParameter, ConnectedorganizationPostExternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}
