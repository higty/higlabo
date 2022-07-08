using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
