using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalitemCreateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionId { get; set; }
            public string? ItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionId_Items_ItemId: return $"/external/connections/{ConnectionId}/items/{ItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionId_Items_ItemId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? Id { get; set; }
        public ExternalConnectorsProperties? Properties { get; set; }
        public ExternalConnectorsExternalitemContent? Content { get; set; }
        public ExternalConnectorsAcl[]? Acl { get; set; }
    }
    public partial class ExternalConnectorsExternalitemCreateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemCreateResponse> ExternalConnectorsExternalitemCreateAsync()
        {
            var p = new ExternalConnectorsExternalitemCreateParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemCreateParameter, ExternalConnectorsExternalitemCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemCreateResponse> ExternalConnectorsExternalitemCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalitemCreateParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemCreateParameter, ExternalConnectorsExternalitemCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemCreateResponse> ExternalConnectorsExternalitemCreateAsync(ExternalConnectorsExternalitemCreateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemCreateParameter, ExternalConnectorsExternalitemCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemCreateResponse> ExternalConnectorsExternalitemCreateAsync(ExternalConnectorsExternalitemCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemCreateParameter, ExternalConnectorsExternalitemCreateResponse>(parameter, cancellationToken);
        }
    }
}
