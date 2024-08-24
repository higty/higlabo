using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalItemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }
            public string? ExternalItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Items_ExternalItemId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class ExternalConnectorsExternalItemGetResponse : RestApiResponse
    {
        public ExternalConnectorsAcl[]? Acl { get; set; }
        public ExternalConnectorsExternalItemContent? Content { get; set; }
        public string? Id { get; set; }
        public ExternalConnectorsProperties? Properties { get; set; }
        public ExternalConnectorsExternalActivity[]? Activities { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemGetResponse> ExternalConnectorsExternalItemGetAsync()
        {
            var p = new ExternalConnectorsExternalItemGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemGetParameter, ExternalConnectorsExternalItemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemGetResponse> ExternalConnectorsExternalItemGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalItemGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemGetParameter, ExternalConnectorsExternalItemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemGetResponse> ExternalConnectorsExternalItemGetAsync(ExternalConnectorsExternalItemGetParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemGetParameter, ExternalConnectorsExternalItemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemGetResponse> ExternalConnectorsExternalItemGetAsync(ExternalConnectorsExternalItemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemGetParameter, ExternalConnectorsExternalItemGetResponse>(parameter, cancellationToken);
        }
    }
}
