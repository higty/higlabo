using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalconnectionPostGroupsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups: return $"/external/connections/{ConnectionsId}/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups,
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
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class ExternalConnectorsExternalconnectionPostGroupsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionPostGroupsResponse> ExternalConnectorsExternalconnectionPostGroupsAsync()
        {
            var p = new ExternalConnectorsExternalconnectionPostGroupsParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionPostGroupsParameter, ExternalConnectorsExternalconnectionPostGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionPostGroupsResponse> ExternalConnectorsExternalconnectionPostGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionPostGroupsParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionPostGroupsParameter, ExternalConnectorsExternalconnectionPostGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionPostGroupsResponse> ExternalConnectorsExternalconnectionPostGroupsAsync(ExternalConnectorsExternalconnectionPostGroupsParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionPostGroupsParameter, ExternalConnectorsExternalconnectionPostGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionPostGroupsResponse> ExternalConnectorsExternalconnectionPostGroupsAsync(ExternalConnectorsExternalconnectionPostGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionPostGroupsParameter, ExternalConnectorsExternalconnectionPostGroupsResponse>(parameter, cancellationToken);
        }
    }
}
