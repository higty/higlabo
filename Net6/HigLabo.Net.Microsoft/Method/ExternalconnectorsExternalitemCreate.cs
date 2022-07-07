using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalitemCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_ConnectionId_Items_ItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionId_Items_ItemId: return $"/external/connections/{ConnectionId}/items/{ItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? Id { get; set; }
        public Properties? Properties { get; set; }
        public ExternalItemContent? Content { get; set; }
        public Acl[]? Acl { get; set; }
        public string ConnectionId { get; set; }
        public string ItemId { get; set; }
    }
    public partial class ExternalconnectorsExternalitemCreateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemCreateResponse> ExternalconnectorsExternalitemCreateAsync()
        {
            var p = new ExternalconnectorsExternalitemCreateParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemCreateParameter, ExternalconnectorsExternalitemCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemCreateResponse> ExternalconnectorsExternalitemCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalitemCreateParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemCreateParameter, ExternalconnectorsExternalitemCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemCreateResponse> ExternalconnectorsExternalitemCreateAsync(ExternalconnectorsExternalitemCreateParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemCreateParameter, ExternalconnectorsExternalitemCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemCreateResponse> ExternalconnectorsExternalitemCreateAsync(ExternalconnectorsExternalitemCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemCreateParameter, ExternalconnectorsExternalitemCreateResponse>(parameter, cancellationToken);
        }
    }
}
