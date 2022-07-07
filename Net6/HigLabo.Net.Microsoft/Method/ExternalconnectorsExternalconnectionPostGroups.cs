using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalconnectionPostGroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups: return $"/external/connections/{ConnectionsId}/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string ConnectionsId { get; set; }
    }
    public partial class ExternalconnectorsExternalconnectionPostGroupsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionPostGroupsResponse> ExternalconnectorsExternalconnectionPostGroupsAsync()
        {
            var p = new ExternalconnectorsExternalconnectionPostGroupsParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionPostGroupsParameter, ExternalconnectorsExternalconnectionPostGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionPostGroupsResponse> ExternalconnectorsExternalconnectionPostGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalconnectionPostGroupsParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionPostGroupsParameter, ExternalconnectorsExternalconnectionPostGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionPostGroupsResponse> ExternalconnectorsExternalconnectionPostGroupsAsync(ExternalconnectorsExternalconnectionPostGroupsParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionPostGroupsParameter, ExternalconnectorsExternalconnectionPostGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionPostGroupsResponse> ExternalconnectorsExternalconnectionPostGroupsAsync(ExternalconnectorsExternalconnectionPostGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionPostGroupsParameter, ExternalconnectorsExternalconnectionPostGroupsResponse>(parameter, cancellationToken);
        }
    }
}
