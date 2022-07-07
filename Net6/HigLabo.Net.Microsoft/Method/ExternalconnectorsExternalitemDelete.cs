using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalitemDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Items_ExternalItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectionsId { get; set; }
        public string ExternalItemId { get; set; }
    }
    public partial class ExternalconnectorsExternalitemDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemDeleteResponse> ExternalconnectorsExternalitemDeleteAsync()
        {
            var p = new ExternalconnectorsExternalitemDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemDeleteParameter, ExternalconnectorsExternalitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemDeleteResponse> ExternalconnectorsExternalitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalitemDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemDeleteParameter, ExternalconnectorsExternalitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemDeleteResponse> ExternalconnectorsExternalitemDeleteAsync(ExternalconnectorsExternalitemDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemDeleteParameter, ExternalconnectorsExternalitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemDeleteResponse> ExternalconnectorsExternalitemDeleteAsync(ExternalconnectorsExternalitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemDeleteParameter, ExternalconnectorsExternalitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
