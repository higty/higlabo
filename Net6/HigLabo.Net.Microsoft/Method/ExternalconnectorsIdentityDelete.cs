using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsIdentityDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionId { get; set; }
            public string? ExternalGroupId { get; set; }
            public string? IdentityId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionId_Groups_ExternalGroupId_Members_IdentityId: return $"/external/connections/{ConnectionId}/groups/{ExternalGroupId}/members/{IdentityId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionId_Groups_ExternalGroupId_Members_IdentityId,
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
    public partial class ExternalConnectorsIdentityDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsIdentityDeleteResponse> ExternalConnectorsIdentityDeleteAsync()
        {
            var p = new ExternalConnectorsIdentityDeleteParameter();
            return await this.SendAsync<ExternalConnectorsIdentityDeleteParameter, ExternalConnectorsIdentityDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsIdentityDeleteResponse> ExternalConnectorsIdentityDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsIdentityDeleteParameter();
            return await this.SendAsync<ExternalConnectorsIdentityDeleteParameter, ExternalConnectorsIdentityDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsIdentityDeleteResponse> ExternalConnectorsIdentityDeleteAsync(ExternalConnectorsIdentityDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsIdentityDeleteParameter, ExternalConnectorsIdentityDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsIdentityDeleteResponse> ExternalConnectorsIdentityDeleteAsync(ExternalConnectorsIdentityDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsIdentityDeleteParameter, ExternalConnectorsIdentityDeleteResponse>(parameter, cancellationToken);
        }
    }
}
