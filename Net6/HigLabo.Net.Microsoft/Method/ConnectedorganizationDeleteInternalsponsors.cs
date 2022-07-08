using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationDeleteInternalsponsorsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectedOrganizationId { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId_InternalSponsors_Id_ref: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}/internalSponsors/{Id}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId_InternalSponsors_Id_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
