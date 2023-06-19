using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalitemUpdateParameter : IRestApiParameter
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
        public ExternalConnectorsExternalitemContent? Content { get; set; }
        public Object? Properties { get; set; }
    }
    public partial class ExternalConnectorsExternalitemUpdateResponse : RestApiResponse
    {
        public ExternalConnectorsAcl[]? Acl { get; set; }
        public ExternalConnectorsExternalitemContent? Content { get; set; }
        public string? Id { get; set; }
        public ExternalConnectorsProperties? Properties { get; set; }
        public ExternalConnectorsExternalactivity[]? Activities { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalitemUpdateResponse> ExternalConnectorsExternalitemUpdateAsync()
        {
            var p = new ExternalConnectorsExternalitemUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemUpdateParameter, ExternalConnectorsExternalitemUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalitemUpdateResponse> ExternalConnectorsExternalitemUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalitemUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemUpdateParameter, ExternalConnectorsExternalitemUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalitemUpdateResponse> ExternalConnectorsExternalitemUpdateAsync(ExternalConnectorsExternalitemUpdateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemUpdateParameter, ExternalConnectorsExternalitemUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalitemUpdateResponse> ExternalConnectorsExternalitemUpdateAsync(ExternalConnectorsExternalitemUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemUpdateParameter, ExternalConnectorsExternalitemUpdateResponse>(parameter, cancellationToken);
        }
    }
}
