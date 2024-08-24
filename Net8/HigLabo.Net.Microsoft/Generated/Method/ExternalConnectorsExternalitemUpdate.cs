using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalItemUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public ExternalConnectorsAcl[]? Acl { get; set; }
        public ExternalConnectorsExternalItemContent? Content { get; set; }
        public Object? Properties { get; set; }
    }
    public partial class ExternalConnectorsExternalItemUpdateResponse : RestApiResponse
    {
        public ExternalConnectorsAcl[]? Acl { get; set; }
        public ExternalConnectorsExternalItemContent? Content { get; set; }
        public string? Id { get; set; }
        public ExternalConnectorsProperties? Properties { get; set; }
        public ExternalConnectorsExternalActivity[]? Activities { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemUpdateResponse> ExternalConnectorsExternalItemUpdateAsync()
        {
            var p = new ExternalConnectorsExternalItemUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemUpdateParameter, ExternalConnectorsExternalItemUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemUpdateResponse> ExternalConnectorsExternalItemUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalItemUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemUpdateParameter, ExternalConnectorsExternalItemUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemUpdateResponse> ExternalConnectorsExternalItemUpdateAsync(ExternalConnectorsExternalItemUpdateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemUpdateParameter, ExternalConnectorsExternalItemUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemUpdateResponse> ExternalConnectorsExternalItemUpdateAsync(ExternalConnectorsExternalItemUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemUpdateParameter, ExternalConnectorsExternalItemUpdateResponse>(parameter, cancellationToken);
        }
    }
}
